using UnityEngine;

namespace Claw.Rendering.Materials {
	[CreateAssetMenu(fileName = "MatProp_Color", menuName = "Claw/MaterialProperties/Color", order = 3)]
	public class MaterialPropertyColor : MaterialPropertyTemplate<Color> {
		
		public override void Apply(MaterialPropertyBlock propertyBlock) {
			propertyBlock.SetColor(Identifier, Value);
		}
	}
}