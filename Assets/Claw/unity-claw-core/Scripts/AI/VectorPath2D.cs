using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Claw.AI {
	public class VectorPath2D : MonoBehaviour {

		[SerializeField] private List<Vector2> nodes = new List<Vector2>();

		public int Length { get { return nodes.Count; } }
		public Vector2 this[int key] { get { return nodes[key] + (Vector2)transform.position; } }
		
		public Vector2 GetNode(int index) {
			return nodes[index] + (Vector2)transform.position;
		}

		private void OnDrawGizmosSelected() {

			Gizmos.color = Color.green;
			for(int i = 0; i < nodes.Count - 1; i++) {
				Gizmos.DrawLine(this[i], this[i + 1]);
			}	
		}
	}
}
