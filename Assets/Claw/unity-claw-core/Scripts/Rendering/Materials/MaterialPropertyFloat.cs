using UnityEngine;

namespace Claw.Rendering.Materials {
	[CreateAssetMenu(fileName = "MatProp_Float", menuName = "Claw/MaterialProperties/Float", order = 1)]
	public class MaterialPropertyFloat : MaterialPropertyTemplate<float> {

		public override void Apply(MaterialPropertyBlock propertyBlock) {
			propertyBlock.SetFloat(Identifier, Value);
		}
	}
}