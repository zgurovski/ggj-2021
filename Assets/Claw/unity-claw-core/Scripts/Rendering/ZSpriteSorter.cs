using UnityEngine;

namespace Claw.Rendering {
	[ExecuteInEditMode]
	public class ZSpriteSorter : MonoBehaviour {
		
		private void Update() {
			GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(-transform.position.z * 10);
		}
	}
}
