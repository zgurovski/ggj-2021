using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFollow : MonoBehaviour
{

    public AIPath aIPath;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        direction = aIPath.desiredVelocity;

        this.GetComponent<Rigidbody2D>().MovePosition(direction);

       

        
    }
}