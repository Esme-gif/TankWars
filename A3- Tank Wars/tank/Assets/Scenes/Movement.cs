using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    private GameObject target;
    private Vector3 movement;
    public string objectTag1;
    public string objectTag2;

    private bool isRoaming = false;
    private bool isMovingL = false;
    private bool isMovingR = false;
    private bool isMovingU = false;
    private bool isMovingD = false;
    private bool isMoving = false;

    void Start()
    {
        target = null;

    }

    void FixedUpdate()
    {
        Rigidbody myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.velocity = Vector3.zero;
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
            if ((96 <= angle && angle <= 180) || (angle >= -180 && angle <= -96))
            {
                //left
                LDirectionMovement(myRigidBody);
            }
            else if ((83 <= angle && angle <= -83))
            {
                // right
                RDirectionMovement(myRigidBody);
            }
            else if (angle < 96 && angle > 83)
            {
                // up
                UDirectionMovement(myRigidBody);
            }
            else if (angle > -96 && angle < -83)
            {
                //down
                DDirectionMovement(myRigidBody);

            }
        }
        else
        {
            if (isRoaming == false)
            {
                StartCoroutine(Roaming());
            }
            if (isMoving)
            {
                if (myRigidBody)
                {
                    if (isMovingU)
                    {
                        UDirectionMovement(myRigidBody);
                    }
                    else if (isMovingD)
                    {
                        DDirectionMovement(myRigidBody);
                    }
                    else if (isMovingL)
                    {
                        LDirectionMovement(myRigidBody);
                    }
                    else if (isMovingR)
                    {
                        RDirectionMovement(myRigidBody);
                    }
                }
            }
        }
    }


    IEnumerator Roaming()
    {
        int rDirection = Random.Range(1, 5);
        int movingTime = Random.Range(1, 4);
        int movingWait = Random.Range(0, 2);

        isRoaming = true;

        yield return new WaitForSeconds(movingWait);
        if (rDirection == 1)
        {
            isMovingU = true;
        }
        else if (rDirection == 2)
        {
            isMovingD = true;
        }
        else if (rDirection == 3)
        {
            isMovingL = true;
        }
        else if (rDirection == 4)
        {
            isMovingR = true;
        }
        isMoving = true;
        yield return new WaitForSeconds(movingTime);
        isMoving = false;
        isMovingU = false;
        isMovingD = false;
        isMovingL = false;
        isMovingR = false;

        isRoaming = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (target == null && (other.gameObject.CompareTag(objectTag1) || other.gameObject.CompareTag(objectTag2)))
        {
            isRoaming = false;
            target = other.gameObject;
        }
    }

    private void UDirectionMovement(Rigidbody myRigid)
    {
        transform.forward = Vector3.forward;
        myRigid.velocity = new Vector3(0, 0, speed);
    }
    private void DDirectionMovement(Rigidbody myRigid)
    {
        transform.forward = Vector3.back;
        myRigid.velocity = new Vector3(0, 0, -speed);
    }
    private void RDirectionMovement(Rigidbody myRigid)
    {
        transform.forward = Vector3.right;
        myRigid.velocity = new Vector3(speed, 0, 0);
    }
    private void LDirectionMovement(Rigidbody myRigid)
    {
        transform.forward = Vector3.left;
        myRigid.velocity = new Vector3(-speed, 0, 0);
    }
/*
    void Shoot()
    {
        var bullet = Instantiate(six_bullets, barrelsEnd.position, barrelsEnd.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(0.25f);
        canShoot = true;
    }
    */
}
