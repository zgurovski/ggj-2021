using System;
using System.Collections.Generic;
using UnityEngine;

namespace Claw.AI.Steering {
    [RequireComponent(typeof(Rigidbody2D))]
    public class SteeringController : MonoBehaviour {

        [SerializeField] private float maxSpeed = 12.0f;
        [SerializeField] private float maxForce = 10.0f;
        [SerializeField] private float maxRotation = 20.0f; 
        private Rigidbody2D rBody;
        private List<SteeringBehaviour> behaviours;
        private Vector2 accumForce;

        public float MaxSpeed { get { return maxSpeed; } }
        public float MaxForce { get { return maxForce; } }
        public float MaxRotation { get { return maxRotation; } }
        
        public T AddBehaviourBack<T>() where T : SteeringBehaviour {
            return AddBehaviour<T>(behaviours.Count);
        }

        public T AddBehaviourFront<T>() where T : SteeringBehaviour {
            return AddBehaviour<T>(0);
        }
        
        public T AddBehaviour<T>(int pos = 0) where T : SteeringBehaviour {
            T newBehaviour = gameObject.AddComponent<T>();

            if (pos < 0) { pos = 0; }
            else if (pos > behaviours.Count) { pos = behaviours.Count; }

            behaviours.Insert(pos, newBehaviour);
            newBehaviour.Initialize();
            return newBehaviour;
        }

        private void Start() {
            rBody = GetComponent<Rigidbody2D>();
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
            foreach (var behaviour in behaviours) {
                behaviour.Initialize();
            }
        }

        private void FixedUpdate() {
            accumForce = Vector2.zero;

            foreach (SteeringBehaviour behaviour in behaviours) {
                if (!behaviour.enabled) {
                    continue;
                }

                Vector2 force = behaviour.CalculateForce();
                if (!AccumulateForce(force)) {
                    break;
                }
            }
            
            rBody.AddForce(accumForce, ForceMode2D.Impulse);
        }

        private void Update() {
            if (rBody.velocity.sqrMagnitude > 0.00001f) {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, rBody.velocity);
            }
        }
        
        private bool AccumulateForce(Vector2 toAdd) {
            
            float magCurrent = accumForce.magnitude;

            float magRemaining = maxForce - magCurrent;
            if (magRemaining <= 0.0f) { return false; }

            float magToAdd = toAdd.magnitude;
            if (magToAdd > magRemaining) {
                accumForce += toAdd.normalized * magRemaining;
                return false;
            }
         
            accumForce += toAdd;
            return true;
        }
    }
}