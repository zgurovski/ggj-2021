using UnityEngine;

namespace Claw.AI.Steering {
    [RequireComponent(typeof(NeighbourAwareness))]
    public class Cohesion : SteeringBehaviour {

        private NeighbourAwareness neighbours;
        private Seek seek;

        protected override void OnInitialize() {
            neighbours = GetComponent<NeighbourAwareness>();
            seek = RequireBehaviour<Seek>();
        }

        protected override Vector2 DoForceCalculation() {

            Vector2 centerOfMass = Vector2.zero;
            Vector2 steeringForce = Vector2.zero;
            
            for (int i = 0; i < neighbours.NeighbourCount; i++) {
                
                Collider2D neighbour = neighbours.GetNeighbour(i);

                centerOfMass += (Vector2)neighbour.transform.position;
            }

            if (neighbours.NeighbourCount > 0) {
                
                centerOfMass /= neighbours.NeighbourCount;

                steeringForce = seek.CalculateForce(centerOfMass);
            }
            
            return steeringForce;
        }
    }
}