using System;
using UnityEngine;

namespace Claw.Controls {
    public class ButtonSequenceDetector : MonoBehaviour {

        [SerializeField] private bool sendEvent = true;
        [SerializeField] private Sequence sequence;

        private int nextBtn = 0;
        private float tStart = 0.0f;

        public event Action<string> OnCompleted;

        private void Update() {

            if (Input.anyKeyDown && !Input.GetButtonDown(sequence.GetInput(nextBtn))) {
                nextBtn = 0;
            }
            else if (Input.GetButtonDown(sequence.GetInput(nextBtn))) {
                if (nextBtn == 0) {
                    tStart = Time.time;
                    nextBtn++;
                }
                else {
                    float dTime = Time.time - tStart;

                    if (dTime < sequence.TimeLimit) {
                        nextBtn++;

                        if (nextBtn == sequence.Length) {

                            if (sendEvent) {
                                EventManager.QueueEvent(new SequenceCompletedEvent(sequence.Name));
                            }

                            if (OnCompleted != null) {
                                OnCompleted.Invoke(sequence.Name);
                            }

                            nextBtn = 0;
                        }
                    }
                    else {
                        nextBtn = 0;
                    }
                }
            }
        }
    }
}