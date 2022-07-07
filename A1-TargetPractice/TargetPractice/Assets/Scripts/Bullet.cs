using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this just destroys the bullets when hitting an object
// such as:
//     Arena Walls
//     Walls within the arena
//     targets
// does not include the tank

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Tank")
        {
            Destroy(gameObject);
        }
    }
}
