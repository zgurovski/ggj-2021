using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Claw.Rendering {
    public class RecursiveRendererSort : MonoBehaviour {

        [SerializeField] private int sortOrder;

        void Start() {
            ChangeSortingOrder(sortOrder);
        }

        public void ChangeSortingOrder(int order) {
            foreach (Renderer r in GetComponentsInChildren<Renderer>()) {
                r.sortingOrder += order;
            }
        }

        public void SetSortingOrder(int order) {
            foreach (Renderer r in GetComponentsInChildren<Renderer>()) {
                r.sortingOrder = order;
            }
        }
    }
}