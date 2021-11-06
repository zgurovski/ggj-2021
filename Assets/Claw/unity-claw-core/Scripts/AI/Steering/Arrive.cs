using UnityEngine;

namespace Claw.AI.Steering {
    public class Arrive : SteeringBehaviour {

        [SerializeField] private Transform target;
        [SerializeField] private float decceleration = 1.0f;

        public Vector2 CalculateForce(Vector2 targetPos) {
            
            Vector2 toTarget = targetPos - (Vector2)transform.position;

            float distance = toTarget.magnitude;

            if (distance > 0.0f) {

                float speed = distance / decceleration;

                speed = Mathf.Min(speed, Controller.MaxSpeed);

                Vector2 desiredVel = (toTarget / distance) * speed;

                return desiredVel - Rigidbody.velocity;
            }

            return Vector2.zero;
        }

        protected override Vector2 DoForceCalculation() {

            if (target == null) {
                return Vector2.zero;
            }

            return CalculateForce(target.position);
        }
    }
}