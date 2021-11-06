using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Claw.Objects {
	//Defines a 2D world and its limits
	public class WorldBounds2D : MonoBehaviour {

		[SerializeField] private Vector2 _size = new Vector2(30.0f, 20.0f);

		public Vector2 Center => transform.position;

		public Vector2 Size => _size;

		public float Left { get { return Center.x - Size.x / 2.0f; } }

		public float Right { get { return Center.x + Size.x / 2.0f; } }

		public float Top { get { return Center.y + Size.y / 2.0f; } }

		public float Bottom { get { return Center.y - Size.y / 2.0f; } }

		public Vector2 BottomLeft { get { return new Vector2(Left, Bottom); } }

		public Vector2 TopLeft { get { return new Vector2(Left, Top); } }

		public Vector2 BottomRight { get { return new Vector2(Right, Bottom); } }

		public Vector2 TopRight { get { return new Vector2(Right, Top); } }

		private void OnDrawGizmosSelected() {
			Gizmos.color = Color.green;
			Gizmos.DrawWireCube(Center, Size);
		}
	}
}