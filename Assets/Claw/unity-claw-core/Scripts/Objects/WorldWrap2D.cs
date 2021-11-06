using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Claw.Objects {
	public class WorldWrap2D : MonoBehaviour {

		[SerializeField] private WorldBounds2D bounds;

		private void Start() {
			if (bounds == null) {
				Destroy(this);
			}
		}

		private void Update() {

			Vector2 pos = transform.position;

			if (pos.x < bounds.Left) { pos.x = bounds.Right; }
			if (pos.x > bounds.Right) { pos.x = bounds.Left; }
			if (pos.y < bounds.Bottom) { pos.y = bounds.Top; }
			if (pos.y > bounds.Top) { pos.y = bounds.Bottom; }
			
			transform.position = new Vector3(pos.x, pos.y, transform.position.z);
		}
	}
}
