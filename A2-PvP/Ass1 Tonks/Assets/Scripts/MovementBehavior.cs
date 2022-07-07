using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    //tanks shooting and movement behaviour

    // Start is called before the first frame update

    #region Public Variables
    public Rigidbody m_Bullet;
    public Transform m_BulletSpawn;
    public float m_LaunchForce;
    public float speed;
    public KeyCode f_forward;
    public KeyCode d_down;
    public KeyCode l_left;
    public KeyCode r_right;
    public KeyCode s_shoot;
    #endregion



    #region Movement/Rotation
    private void FixedUpdate()
    {
        // moves based on indicated keys
        
        if (Input.GetKey(f_forward))
        {
            Rigidbody myBody = GetComponent<Rigidbody>();
            if (myBody) //checks if there is a rigidbody??
            {
                transform.forward = Vector3.forward; //changes the direction
                transform.Translate(new Vector3(-speed, 0, 0)); //moves in the direction faced as specified in previous line
            }
        }
        else if (Input.GetKey(d_down))
        {
            Rigidbody myBody = GetComponent<Rigidbody>();
            if (myBody)
            {
                transform.forward = Vector3.back;
                transform.Translate(new Vector3(-speed, 0, 0));
            }
        }
        else if (Input.GetKey(l_left))
        {
            Rigidbody myBody = GetComponent<Rigidbody>();
            if (myBody)
            {
                transform.forward = Vector3.left;
                transform.Translate(new Vector3(-speed, 0, 0));
            }
        }
        else if (Input.GetKey(r_right))
        {
            Rigidbody myBody = GetComponent<Rigidbody>();
            if (myBody)
            {
                transform.forward = Vector3.right;
                transform.Translate(new Vector3(-speed, 0, 0));
            }
        }
    }
    #endregion


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
               
        // Shooting if indicated key is hit
        if (Input.GetKeyDown(s_shoot))
        {
            Rigidbody bullet = Instantiate(m_Bullet, m_BulletSpawn.position, m_BulletSpawn.rotation) as Rigidbody;
            bullet.velocity = m_LaunchForce * m_BulletSpawn.forward;
        }       
    }
}
