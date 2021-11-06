using UnityEngine;
using System.Collections.Generic;

namespace Claw.AI.Pathfinding {
 
    public abstract class PathfindingNode {
        
        public abstract Vector3 Position { get; }

        public abstract IReadOnlyList<PathfindingNode> GetNeighbours();
    }
}