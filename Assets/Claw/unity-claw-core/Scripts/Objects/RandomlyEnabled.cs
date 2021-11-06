using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Claw.Objects {
	public class RandomlyEnabled : MonoBehaviour {

		[SerializeField] private float percentageChanceEnabled = 0.75f;

		private void Start() {

			float randomNumber = Random.Range(0, 101) / 100.0f;

			this.gameObject.SetActive(randomNumber <= percentageChanceEnabled);
		}
	}
}
