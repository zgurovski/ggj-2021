using UnityEngine;

namespace Claw.AI.Steering {
    public class FollowPath : SteeringBehaviour {

        private const float MIN_SEEK_DIST = 0.1f;
        
        [SerializeField] private VectorPath2D path2D;
        [SerializeField] private bool loop = true;
        private Seek seek;
        private Arrive arrive;
        private int curWaypoint;
        private bool finished;

        protected override void OnInitialize() {
            seek = RequireBehaviour<Seek>();
            arrive = loop ? null : RequireBehaviour<Arrive>();
        }

        protected override Vector2 DoForceCalculation() {

            if (path2D == null) {
                return Vector2.zero;
            }

            float speedPerFrame = Controller.MaxSpeed * Time.fixedDeltaTime;
            if (!finished && Vector2.Distance(transform.position, path2D[curWaypoint]) <= speedPerFrame) {
                curWaypoint = (curWaypoint + 1) % path2D.Length;
                
                if (!loop && curWaypoint == path2D.Length - 1) {    //End of path
                    finished = true;
                }
            }

            if (finished) {
                return arrive.CalculateForce(path2D[curWaypoint]);
            }

            return seek.CalculateForce(path2D[curWaypoint]);
        }
    }
}