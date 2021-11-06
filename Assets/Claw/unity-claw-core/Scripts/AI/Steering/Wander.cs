using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Claw.AI.Steering {
    public class Wander : SteeringBehaviour {

        [SerializeField] private float wanderRadius = 3.0f;
        [SerializeField] private float wanderDistance = 1.0f;
        [SerializeField] private float wanderJitter = 0.5f;
        private Vector2 wanderTarget;
        private Seek seek;

        protected override void OnInitialize() {
            wanderTarget = (Vector2)transform.up * wanderRadius;
            seek = RequireBehaviour<Seek>();
        }

        protected override Vector2 DoForceCalculation() {
            
            wanderTarget += new Vector2(
                Random.Range(-1.0f, 1.0f) * wanderJitter,
                Random.Range(-1.0f, 1.0f) * wanderJitter);
            wanderTarget.Normalize();
            wanderTarget *= wanderRadius;

            Vector2 targetLocal = wanderTarget + new Vector2(0.0f, wanderDistance);
            
            Vector2 targetWorld = transform.localToWorldMatrix.MultiplyPoint(targetLocal);

            return seek.CalculateForce(targetWorld);
        }
    }
}