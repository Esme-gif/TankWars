using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{
    public string objectTag1;
    public string objectTag2;
    public GameObject six_bullets;
    public Transform barrelsEnd;
    private bool canShoot = true;
    public int bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    //canShoot = false;
        //    var bullet = Instantiate(six_bullets, barrelsEnd.position, barrelsEnd.rotation);
        //    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        //    StartCoroutine(ShootingYield());
        //}
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(objectTag1) || other.gameObject.CompareTag(objectTag2))
        {
            if (canShoot)
            {
                canShoot = false;
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }
    }


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

    //void OnTriggerEnter(Collision collision)
    //{
    //    if (six_bullets != null)
    //    {
    //        Destroy(six_bullets);
    //    }
    //}
}
