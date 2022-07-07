using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulltet_destruction : MonoBehaviour
{
    public string objectTag1;
    public string objectTag2;

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag(objectTag1) || collision.gameObject.CompareTag(objectTag2))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
