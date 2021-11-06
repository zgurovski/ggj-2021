using UnityEngine;

namespace Claw.AI.Steering {
    /// <summary>
    /// Helps group steering behaviours keep track of their neighbours.
    /// </summary>
    public class NeighbourAwareness : MonoBehaviour {

        [SerializeField] private string neighbourLayer = "Boids";
        [SerializeField] private float visionRadius = 10.0f;
        private int neighbourCount;
        private Collider2D[] neighbours;

        public int NeighbourCount { get { return neighbourCount; } }
        public Collider2D[] Neighbours { get { return neighbours; } }

        public Collider2D GetNeighbour(int index) {
            return neighbours[index];
        }

        private void FixedUpdate() {

            int layerMask = LayerMask.GetMask(neighbourLayer);
            neighbourCount = Physics2D.OverlapCircleNonAlloc(transform.position, visionRadius, neighbours, layerMask);
        }
    }
}