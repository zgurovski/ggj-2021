using UnityEngine;

namespace Claw.Chrono {
	public class TimedBehaviour : MonoBehaviour {
		
		[Header("Timer Parameters")] 
		[SerializeField] private float originalFrequency;
		[SerializeField] private float volatility;

		private float timer;
		private float frequency;
		private bool paused;

		public bool Paused { get { return paused; } set { paused = value; } }

		public void AddDelay(float delay) {
			timer -= delay;
		}
		
		public void ResetTimer() {
			timer = 0f;
		}

		void LateUpdate() {
			if (paused) {
				return;
			}

			timer += Time.deltaTime;
			if (timer > frequency) {
				
				float frequencyAdjust = (-0.5f + Random.value) * volatility;
				float newFreq = originalFrequency + frequencyAdjust;
				frequency = newFreq <= 0.0f ? originalFrequency : newFreq;
				
				ResetTimer();
				OnTimerReached();
			}
		}

		protected virtual void OnTimerReached() {
			
		}
	}
}
