using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShotController : MonoBehaviour
{
    // Start is called before the first frame update
   
    Transform playerTransform;
    public GameObject laserPrefab;
    public AudioSource litening2;

    void Start()
    {
        playerTransform = GameObject.Find("Wall").GetComponent<Transform>();
        InvokeRepeating("shoot", 1, 4);
        litening2 = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.LookAt(playerTransform.position);
    }

    void shoot()
    {
        litening2.Play();
        GameObject g = Instantiate(laserPrefab,
            transform.position, transform.rotation);
        

        Rigidbody bod = g.GetComponent<Rigidbody>();
        bod.velocity = transform.forward * 20;
    }
}