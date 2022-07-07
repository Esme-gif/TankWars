using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    #region Private Methods
    private void OnCollisionEnter(Collision collision)
    {
        // If bullet hits the arena
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
            Debug.Log("Bullet hit Arena.");
        }
        // Or if bullet hits an enemy tank
        else if (collision.gameObject.name == "Tenk")
        {
            Destroy(gameObject);
            Debug.Log("Tenk enemy hit");
        }
        else if (collision.gameObject.name == "Tonk")
        {
            Destroy(gameObject);
            Debug.Log("Tonk enemy hit");
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}