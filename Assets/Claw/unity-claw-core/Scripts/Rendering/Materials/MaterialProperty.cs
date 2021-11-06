using UnityEngine;

namespace Claw.Rendering.Materials {
	public abstract class MaterialProperty : ScriptableObject {

		[SerializeField] private string _identifier;

		protected string Identifier => _identifier;

		public abstract void Apply(MaterialPropertyBlock propertyBlock);
	}
}