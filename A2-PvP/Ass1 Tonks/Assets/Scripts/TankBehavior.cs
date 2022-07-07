using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehavior : MonoBehaviour
{
    //Tanks getting shot and respawning script

    // heirarchy -> Spawn
    // got the Spawn children and put them in a Transform array
    public Transform[] spawnPoints;
    public GameObject enemyTank;
    

    // if enemy bullet hits the tank
    private void OnCollisionEnter(Collision collision)
    {
        // If an enemy tank collides with enemy bullet, then...
        if (collision.gameObject.name == "Te_Bullet(Clone)" && gameObject.name == "Tonk")
        {
            //making tank "invisable"
            gameObject.SetActive(false);
            Invoke("Spawn", 2); //delay of 2 seconds
           
        }
        else if (collision.gameObject.name == "To_Bullet(Clone)" && gameObject.name == "Tenk")
        {
            
            //making tank "invisable"
            gameObject.SetActive(false);
            Invoke("Spawn", 1); //delay of 2 seconds

        }
    }

    //First I tried to Instantiate the tanks, but it kept on disabling the scripts that made the tanks move, shoot, etc. 
    // I couldn't figure out why it didn't work so instead I changed how I respawned
    //then for the delay Coroutines was not working for me, so I used Invoke instead
    // lastly I had many spawn points but I could figure out how to prevent overlapping so I went with just repositioning them both after the delay

    //basically repositions the tanks after a delay and makes the tank "invisible" tank "visible" again
    private void Spawn()
    {
        //change positions of tanks
        gameObject.transform.position = spawnPoints[0].position;
        enemyTank.transform.position = spawnPoints[1].position;
        //set the velocity of tanks to zero so there is no sliding
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        enemyTank.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //made tank "visible" again
        gameObject.SetActive(true);
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
