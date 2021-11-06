using System.Collections;
using System.Collections.Generic;

namespace Claw.AI.Pathfinding {
    
    public class Area<T> : IReadOnlyList<T> where T : PathfindingNode {

        private readonly List<T> _area = null;
        
        public int Count => _area.Count;

        public T this[int index] => _area[index];
        
        public bool Contains(T pos) { return _area.Contains(pos); }

        public IEnumerator<T> GetEnumerator() { return _area.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return _area.GetEnumerator(); }

        public Area(List<T> area) {
            _area = area;
        }
    }
}
