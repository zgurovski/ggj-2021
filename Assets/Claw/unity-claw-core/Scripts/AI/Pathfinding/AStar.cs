using UnityEngine;
using System.Collections.Generic;

namespace Claw.AI.Pathfinding {
    
    public class AStar<T> where T : PathfindingNode {
        
        private class NodeMeta<T> {

            public float HCost;
        
            public float GCost;
        
            public float FCost => HCost + GCost;

            public T Parent;

            public T Node { get; }

            public NodeMeta(T node) {
                Node = node;
            }
        }
        
        private readonly List<NodeMeta<T>> _closedList = new List<NodeMeta<T>>();
        private readonly List<NodeMeta<T>> _openList = new List<NodeMeta<T>>();
        private readonly Dictionary<T, NodeMeta<T>> _metaData = new Dictionary<T, NodeMeta<T>>();
        
        private T _startNode;
        private T _endNode;
        private ITraverser<T> _traverser;
        private NodeMeta<T> _current;

        public Path<T> GetPath(T startNode, T endNode, ITraverser<T> traverser) {
            if(startNode == _endNode) {
                return new Path<T>(new List<T>() { startNode });   
            }

            _startNode = startNode;
            _endNode = endNode;
            _traverser = traverser;
            
            _closedList.Clear();
            _openList.Clear();

            var startNodeMeta = GetNodeMeta(startNode);

            startNodeMeta.GCost = 0.0f;

            _openList.Add(startNodeMeta);

            while (true) {
                
                if(_openList.Count == 0) {
                    return Path<T>.Empty;  // No path exists
                }

                _current = _openList[_openList.Count - 1];
                _openList.Remove(_current);

                if(_current.Node == endNode) {
                    return Backtrack();    // Path discovered
                }
                
                if(!_closedList.Contains(_current)) {
                    _closedList.Add(_current);
                    AddNeighboursToOpen();
                }
            }
        }

        private Path<T> Backtrack() {
            List<T> path = new List<T>();

            while(_current.Node != _startNode) {
                if(_traverser.AddToResult(_current.Node)) { 
                    path.Add(_current.Node);
                }
                _current = GetNodeMeta(_current.Parent);
            }

            if(_traverser.AddToResult(_current.Node)) {
                path.Add(_startNode);
            }

            path.Reverse();

            return new Path<T>(path);
        }

        private void AddNeighboursToOpen() {
            foreach(T neighbour in _current.Node.GetNeighbours()) {
                AddToOpen(neighbour);
            }

            _openList.Sort((a, b) => b.FCost.CompareTo(a.FCost));
        }

        private void AddToOpen(T node) {
            NodeMeta<T> target = GetNodeMeta(node);
            if(_traverser.CanTraverse(node) || node == _endNode) {
                float gCost = _current.GCost + _traverser.GetTraverseCost(_current.Node, node);
                if (!_closedList.Contains(target) && !_openList.Contains(target)) {
                    target.Parent = _current.Node;
                    target.HCost = Vector3.Distance(node.Position, _endNode.Position);
                    target.GCost = gCost;
                    _openList.Add(target);
                }
                else if(target.GCost > gCost) {
                    target.Parent = _current.Node;
                    target.GCost = gCost;
                }
            }
        }

        private NodeMeta<T> GetNodeMeta(T node) {
            NodeMeta<T> metaData = null;
            if (!_metaData.TryGetValue(node, out metaData)) {
                metaData = new NodeMeta<T>(node);
                _metaData.Add(node, metaData);
            }

            return metaData;
        }
    }
}
