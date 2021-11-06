namespace Claw.AI.Pathfinding {

    public class Pathfinder<T> where T : PathfindingNode {

        private readonly AStar<T> _astar;
        private readonly SimpleFill<T> _simpleFill;

        public Pathfinder() {
            _astar = new AStar<T>();
            _simpleFill = new SimpleFill<T>();
        }

        public Path<T> GetPath(T start, T end, ITraverser<T> traverser) {
            return _astar.GetPath(start, end, traverser);
        }

        public Area<T> GetArea(T center, int range, ITraverser<T> traverser) {
            return _simpleFill.GetFill(center, range, traverser);
        }
    }
}
