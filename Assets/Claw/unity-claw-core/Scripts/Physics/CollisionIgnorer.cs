using UnityEngine;

namespace Claw.Physics {
	public class CollisionIgnorer : MonoBehaviour {

		[SerializeField] private string layerToIgnore;

		private void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.layer == LayerMask.NameToLayer(layerToIgnore)) {
				UnityEngine.Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
			}
		}
	}
}
