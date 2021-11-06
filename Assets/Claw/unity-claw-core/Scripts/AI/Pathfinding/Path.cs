using System.Collections.Generic;
using System.Collections;

namespace Claw.AI.Pathfinding {
    
    public class Path<T> : IReadOnlyList<T> where T : PathfindingNode {

        private readonly List<T> _nodes;

        public T Start => _nodes[0];
        
        public T End => _nodes[_nodes.Count - 1];
        
        public int Length => _nodes == null ? 0 : _nodes.Count;
        
        public bool Exists => _nodes != null;
        
        public int Count => _nodes.Count;
        
        public T this[int index] => _nodes[index];
        
        public static Path<T> Empty => new Path<T>();

        public Path(List<T> nodes) { this._nodes = nodes; }

        public Path(T[] pathNodes) { this._nodes = new List<T>(pathNodes); }
        
        private Path() { }
        
        public IEnumerator<T> GetEnumerator() { return _nodes.GetEnumerator(); }
        
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}