using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMcnt : MonoBehaviour
{ 
 ParticleSystem Aexp2;
    ParticleSystem Dexp2;
    public AudioSource litening2;
    Rigidbody bod;
    // Start is called before the first frame update
    void Start()
    {
    bod = GetComponent<Rigidbody>();
        Aexp2 = transform.Find("Aexp2").GetComponent<ParticleSystem>();
        Dexp2 = transform.Find("Dexp2").GetComponent<ParticleSystem>();
        litening2 = GetComponent<AudioSource>();
    }

void OnCollisionEnter(Collision collision)
{
    Destroy(bod);
    Destroy(Aexp2);
    Dexp2.Play();
    litening2.Play();
    Destroy(gameObject, 2);

}

}
