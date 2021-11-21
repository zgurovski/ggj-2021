using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    public GameObject dog;
    Vector3 rotation;
    
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(this.transform.rotation.x, this.transform.rotation.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
      //  this.transform.rotation = rotation;
    }
}
