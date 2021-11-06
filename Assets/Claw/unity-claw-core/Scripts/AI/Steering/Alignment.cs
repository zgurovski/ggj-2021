using UnityEngine;

namespace Claw.AI.Steering {
    [RequireComponent(typeof(NeighbourAwareness))]
    public class Alignment : SteeringBehaviour {

        private NeighbourAwareness neighbours;

        protected override void OnInitialize() {
            neighbours = GetComponent<NeighbourAwareness>();
        }

        protected override Vector2 DoForceCalculation() {

            Vector2 avgHeading = Vector2.zero;
            
            for (int i = 0; i < neighbours.NeighbourCount; i++) {
                Collider2D neighbour = neighbours.GetNeighbour(i);
                avgHeading += (Vector2)neighbour.transform.up;
            }

            if (neighbours.NeighbourCount > 0) {
                avgHeading /= neighbours.NeighbourCount;
                avgHeading -= (Vector2)transform.up;
            }

            return avgHeading;
        }

    }
}