using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsLeftController : MonoBehaviour
{
    SpriteRenderer item1, item2, item3, item4, item5;

    // Start is called before the first frame update
    void Start()
    {
        item1 = GameObject.Find("Item1").GetComponent<SpriteRenderer>();
        item2 = GameObject.Find("Item2").GetComponent<SpriteRenderer>();
        item3 = GameObject.Find("Item3").GetComponent<SpriteRenderer>();
        item4 = GameObject.Find("Item4").GetComponent<SpriteRenderer>();
        item5 = GameObject.Find("Item5").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //code conditionals to toggle SpriteRenderers on or off depending on how many have been bought
        //leave implementing this until the GameManager or something else can control what items have or are being bought
    }
}
