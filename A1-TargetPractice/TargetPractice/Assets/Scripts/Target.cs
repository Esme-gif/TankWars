using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//basically this script destroys object if hit by a bullet


public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "bullet(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
