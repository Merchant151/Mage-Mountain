using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    ParticleSystem beam;
    ParticleSystem explo;
    Rigidbody bod;
    // Start is called before the first frame update
    void Start()
    {
        bod = GetComponent<Rigidbody>();
        beam = transform.Find("Beam").GetComponent<ParticleSystem>();
        explo = transform.Find("Explo").GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(bod);
        Destroy(beam);
        explo.Play();
        Destroy(gameObject, 2);
    }

}
