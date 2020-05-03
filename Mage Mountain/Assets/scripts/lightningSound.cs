using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningSound : MonoBehaviour
{
    public AudioSource litening;
    // Start is called before the first frame update
    void Start()
    {
        litening = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            litening.Play();
        }
    }
}
