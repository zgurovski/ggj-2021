using UnityEngine;

namespace Claw.Rendering.Materials {
	public abstract class MaterialPropertyTemplate<T> : MaterialProperty {

		[SerializeField] private T _value;

		public T Value { get => _value; set => _value = value; }
	}
}