using UnityEngine;

namespace Claw.Rendering.Materials {
	[CreateAssetMenu(fileName = "MatProp_Vector", menuName = "Claw/MaterialProperties/Vector", order = 1)]
	public class MaterialPropertyVector : MaterialPropertyTemplate<Vector3> {

		public override void Apply(MaterialPropertyBlock propertyBlock) {
			propertyBlock.SetVector(Identifier, Value);
		}
	}
}