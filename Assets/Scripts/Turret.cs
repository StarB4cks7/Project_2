using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Turret : MonoBehaviour
{
    public Transform laserSpawnPoint;
    public GameObject laserPrefab;
    public float laserSpeed = 10;

    public Transform target;

    public float timeBetweenShots = 2;
    private float timer;


    //Audio

    //public AudioSource source;
    //public AudioClip clip;



    // Start is called before the first frame update
    void Start()
    {
        //Implemented to optimize workflow => i dont have to set target manuallly with this line 

        target = GameObject.FindGameObjectWithTag("Player").transform;

        timer = timeBetweenShots;
    }

    void Update()

    {

        //Shooting automatic 

        timer -= Time.deltaTime;

        if (timer <= 0)

        {
            // Schooting giving the "var laser" properties => 1.Getting the Lasser 2.setting the spawnpoint 3. taking the rottation of the empty gameobejct (spawnpoint)
            var laser = Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);

            //gives the rigidbody on the laserbolt prefab velocity=> Velocity== direction of laserspawnpoint + the variable laserspeed => Uses physics engine 
            laser.GetComponent<Rigidbody>().velocity = laserSpawnPoint.forward * laserSpeed;

            //source.PlayOneShot(clip);

            timer = timeBetweenShots;
        }

        Vector3 relativePos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }


    //Destroy component
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("xLaserBolt"))
        {


            Destroy(gameObject);
            Debug.Log("Nice Shot Kid");


        }


    }




}
