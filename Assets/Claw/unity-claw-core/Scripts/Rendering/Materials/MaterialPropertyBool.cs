using UnityEngine;

namespace Claw.Rendering.Materials {
	[CreateAssetMenu(fileName = "MatProp_Bool", menuName = "Claw/MaterialProperties/Bool", order = 2)]
	public class MaterialPropertyBool : MaterialPropertyTemplate<bool> {

		public override void Apply(MaterialPropertyBlock propertyBlock) {
			propertyBlock.SetFloat(Identifier, Value ? 1.0f : 0.0f);
		}
	}
}