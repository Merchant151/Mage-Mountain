using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    Transform playerTransform;
    public GameObject laserPrefab;
    public AudioSource litening2;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        InvokeRepeating("shoot", 1, 2);
        litening2 = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.LookAt(playerTransform.position);
    }

    void shoot()
    {
        GameObject g = Instantiate(laserPrefab,
            transform.position, transform.rotation);
        litening2.Play();

        Rigidbody bod = g.GetComponent<Rigidbody>();
        bod.velocity = transform.forward * 20;
    }
}