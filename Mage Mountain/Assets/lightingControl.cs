using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightingControl : MonoBehaviour
{
    public ParticleSystem lightning;
    public AudioSource litening2;
    // Start is called before the first frame update
    void Start()
    {
        litening2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            lightning.Emit(1);
            litening2.Play();
        }
    }
}
