using System;
using UnityEngine;

namespace Claw.AI.Steering {
    [RequireComponent(typeof(NeighbourAwareness))]
    public class Separation : SteeringBehaviour {

        private NeighbourAwareness neighbours;

        protected override void OnInitialize() {
            neighbours = GetComponent<NeighbourAwareness>();
        }

        protected override Vector2 DoForceCalculation() {

            Vector2 steeringForce = Vector2.zero;
            
            for (int i = 0; i < neighbours.NeighbourCount; i++) {
                
                Collider2D neighbour = neighbours.GetNeighbour(i);

                Vector2 toNeigh = transform.position - neighbour.transform.position;
                steeringForce += toNeigh.normalized / toNeigh.magnitude;
            }

            return steeringForce;
        }

    }
}