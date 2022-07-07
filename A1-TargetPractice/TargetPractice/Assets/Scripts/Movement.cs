using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //helps with making the movement and rotation happen
    Rigidbody rg;
    private float rotationoffset;
    private float speed = 5f;


    //helps keep player input information and make movement smooth
    private bool _w;
    private bool _s;
    private bool _a;
    private bool _d;
    private bool _shouldMove;


    //initialize stuff (rotationoffset = 0 because they will be facing forward at the start)
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rotationoffset = 0;
        
    }


    // gathers information of the player (doesn't allow for 8 directional movement)
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _w = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _s = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _a = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _d = true;
        }
       
    }


    // here is were the movement and rotation happen
    // movement is done 
    //        if both input and _shouldMove are true
    //        with ridgidbody -> adding force
    //
    //
    //        rotation -> only manipulating the y
    //        offset is set to cancel out the last change


            /*  EX: rotationoffset = 0
                _s = true && _shouldMove = true 
                movement done
                rotation -> transform.rotation = Quaternion.Euler(0, rotationoffset-180 ,0);
                rotationoffset = 180
        
                Next-> _a = true && _shouldMove = true  (rotationoffest = 180 and the y rotation right now should be -180)
                movement done
                rotation -> transform.rotation = Quaternion.Euler(0, rotationoffset-90 ,0);
                rotationoffset = 90

        `       etc. (hopefully that makes sense)
        
       */

    private void FixedUpdate()
    {
        rg.velocity = Vector3.zero;
        _shouldMove = true;
        if (_w && _shouldMove)
        {
            rg.AddForce(Vector3.forward * speed, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Euler(0, rotationoffset-360 ,0);
            rotationoffset = 360;
            _w = false;
        }

        else if (_s && _shouldMove)
        {
            rg.AddForce(Vector3.back * speed, ForceMode.VelocityChange);
            transform.Rotate(0, rotationoffset-180 , 0);
            rotationoffset = 180;
            _s = false;
        }

        else if (_a && _shouldMove)
        {
            rg.AddForce(Vector3.left * speed, ForceMode.VelocityChange);
            transform.Rotate(0, rotationoffset-90 , 0);
            rotationoffset = 90;
            _a = false;
        }

        else if (_d && _shouldMove)
        {
            rg.AddForce(Vector3.right * speed, ForceMode.VelocityChange);
            transform.Rotate(0, rotationoffset - 270, 0);
            rotationoffset = 270;
            _d = false;
        }
      
    }



    // when colliding with anything other than the targets and bullets it would not allow movement
    // this way it will would lessen the chances of tilting the tank in diagnal directions
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "obstacles")
        {
            _shouldMove = false;   
        }
        if (collision.gameObject.name == "Arena")
        {
            _shouldMove = false;   
        }

    }


}
