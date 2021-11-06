using System.Collections.Generic;

namespace Claw.AI.Pathfinding {
    
    public class SimpleFill<T> where T : PathfindingNode {
        
        private class NodeMeta<T> {
            
            public int GCost;
        
            public T Node { get; }

            public NodeMeta(T node) { Node = node; }
        }
        
        private readonly Dictionary<T, NodeMeta<T>> _fillData = new Dictionary<T, NodeMeta<T>>();
        private readonly List<NodeMeta<T>> _fill = new List<NodeMeta<T>>();
        private readonly List<NodeMeta<T>> _frontier = new List<NodeMeta<T>>();

        private ITraverser<T> _traverser;

        public Area<T> GetFill(T center, int range, ITraverser<T> traverser) {
            _traverser = traverser;

            _fill.Clear();
            _frontier.Clear();
            
            NodeMeta<T> first = GetFillData(center);
            first.GCost = 0;
            
            _frontier.Add(GetFillData(center));

            for(int step = 0; step <= range; step++) {
                for(int i = _frontier.Count - 1; i >= 0; i--) {
                    if(_frontier[i].GCost <= step) {
                        _fill.Add(_frontier[i]);
                        AddNeighbours(_frontier[i]);
                        _frontier.RemoveAt(i);
                    }
                }
            }

            List<T> fillResult = new List<T>();
            for(int i = 0; i < _fill.Count; i++) {
                T node = _fill[i].Node;
                if(traverser.CanEndOn(node) && traverser.AddToResult(node)) {
                    fillResult.Add(node);
                }
            }

            return new Area<T>(fillResult);
        }

        private void AddNeighbours(NodeMeta<T> nodeMeta) {
            foreach(var pathfindingNode in nodeMeta.Node.GetNeighbours()) {
                var neighbour = (T) pathfindingNode;
                
                NodeMeta<T> neighNodeMeta = GetFillData(neighbour);
                if(!_frontier.Contains(neighNodeMeta) && _traverser.CanTraverse(neighNodeMeta.Node)) {
                    neighNodeMeta.GCost = nodeMeta.GCost + _traverser.GetTraverseCost(nodeMeta.Node, neighNodeMeta.Node);
                    _frontier.Add(neighNodeMeta);
                }
            }
        }

        private NodeMeta<T> GetFillData(T node) {
            NodeMeta<T> nodeMeta = null;
            if (!_fillData.TryGetValue(node, out nodeMeta)) {
                nodeMeta = new NodeMeta<T>(node);
                _fillData[node] = nodeMeta;
            }

            return nodeMeta;
        }
    }
}