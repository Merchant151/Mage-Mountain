using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotscrip : MonoBehaviour
{
    ParticleSystem Aexp;
    ParticleSystem Dexp;
    Rigidbody bod;
    public AudioSource litening2;
    // Start is called before the first frame update
    void Start()
    {
        bod = GetComponent<Rigidbody>();
        Aexp = transform.Find("Aexp").GetComponent<ParticleSystem>();
        Dexp = transform.Find("Dexp").GetComponent<ParticleSystem>();
        litening2 = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(bod);
        Destroy(Aexp);
        Dexp.Play();
        litening2.Play();
        Destroy(gameObject, 2);
    }

}
