using UnityEngine;

namespace Claw.Rendering.Materials {
	[CreateAssetMenu(fileName = "MatProp_Texture", menuName = "Claw/MaterialProperties/Texture", order = 4)]
	public class MaterialPropertyTexture : MaterialPropertyTemplate<Texture> {
		
		public override void Apply(MaterialPropertyBlock propertyBlock) {
			propertyBlock.SetTexture(Identifier, Value);
		}
	}
}