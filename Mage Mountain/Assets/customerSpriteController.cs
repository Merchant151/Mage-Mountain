using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerSpriteController : MonoBehaviour
{
    SpriteRenderer myRend;
    public Sprite emptySprite, cowManSprite;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            myRend.sprite = cowManSprite;
        }
        else
        {
            myRend.sprite = emptySprite;
        }
    }
}
