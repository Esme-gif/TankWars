using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    // create object to find the position of the player
    GameObject playerObject;

    //offset to make the GameObject of this script look at the player from custom position
    Vector3 cameraoffset;

    // Start is called before the first frame update
    void Start()
    {   //initialize
        playerObject = GameObject.Find("Player");
        cameraoffset = new Vector3(0, 20, -20);
    }

    // Update is called once per frame
    void Update()
    {
        //position the GameObject based on the player position and the offset
        transform.position = playerObject.transform.position + cameraoffset;   
    }
}
