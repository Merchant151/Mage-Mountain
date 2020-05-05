using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    Transform playerTransform;
    public GameObject laserPrefab;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        InvokeRepeating("shoot", 1, 2);
    }

    void Update()
    {
        transform.LookAt(playerTransform.position);
    }

    void shoot()
    {
        GameObject g = Instantiate(laserPrefab,
            transform.position, transform.rotation);

        Rigidbody bod = g.GetComponent<Rigidbody>();
        bod.velocity = transform.forward * 20;
    }
}
