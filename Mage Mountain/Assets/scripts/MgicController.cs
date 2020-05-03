using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgicController : MonoBehaviour
{
  
 ParticleSystem ids;
    ParticleSystem jds;
    ParticleSystem kds;
    public AudioSource litening2;
    Rigidbody bod;
    // Start is called before the first frame update
    void Start()
    {
        bod = GetComponent<Rigidbody>();
        ids = transform.Find("ids").GetComponent<ParticleSystem>();
        jds = transform.Find("jds").GetComponent<ParticleSystem>();
        kds = transform.Find("kds").GetComponent<ParticleSystem>();
        
        litening2 = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        litening2.Play();
        Destroy(bod);
        Destroy(ids);
        jds.Play();
        kds.Play();
        
        Destroy(gameObject, 2);

    }

}