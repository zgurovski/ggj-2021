using System.Collections.Generic;
using UnityEngine;

namespace Claw.Rendering.Materials {
    [ExecuteInEditMode]
    [RequireComponent(typeof(Renderer))]
    public class PerRendererMaterialOptions : MonoBehaviour {

        [SerializeField] private List<MaterialProperty> _materialProperties = new List<MaterialProperty>();
        private MaterialPropertyBlock _propertyBlock;
        private Renderer _renderer;

        private void Start() {
            Initialize();
        }

        private void Reset() {
            Initialize();
        }

        private void OnValidate() {
            Initialize();
        }

        private void Initialize() {
            if(_renderer != null && _propertyBlock != null) return;

            _renderer = GetComponent<Renderer>();
            _propertyBlock = new MaterialPropertyBlock ();
        }

        private void Update() {
            
            foreach (var materialProperty in _materialProperties) {
                if (materialProperty == null) continue;
                
                materialProperty.Apply(_propertyBlock);
            }
            
            _renderer.SetPropertyBlock (_propertyBlock);
        }
    }
}
