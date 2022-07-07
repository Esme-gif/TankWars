using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    // keep information of player input
    private bool _space;

    //get the bullet object from the prefab folder
    public GameObject bulletPrefab;

    //added speed for shooting effect
    private float speed = 50;
   
    

    // get player information
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _space = true;
        }

    }

    // actually do the physics here
    private void FixedUpdate()
    {
        if (_space) {
            // make instantiate of bullet and then basically shoot the bullet
            GameObject bulletObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletR = bulletObject.GetComponent<Rigidbody>();
            instBulletR.velocity = transform.forward * speed;

            //return the _space to false so it would not stay true the whole time and mess up the code
            _space = false;
        }
    }
}
