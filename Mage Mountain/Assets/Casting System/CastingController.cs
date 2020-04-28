using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastingController : MonoBehaviour
{
    GameObject orb;
    RawImage mpT;
    RawImage cdT;

    float cost, regenRate, cooldown;

    bool canCast;

    // Start is called before the first frame update
    void Start()
    {
        orb = transform.Find("Orb").gameObject;
        mpT = GameObject.Find("MPFront").GetComponent<RawImage>();
        cdT = GameObject.Find("CooldownFront").GetComponent<RawImage>();

        cost = -40;
        cooldown = 100;
        canCast = true;
        regenRate = 1;

        InvokeRepeating("Regen", 2, regenRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canCast)
        {
            //change color of staff orb. need to move later
            orb.GetComponent<Renderer>().material.color = Random.ColorHSV();

            //this if has work off twice the cost. seems to be working off the height rather than Pos Y?
            if (mpT.GetComponent<RectTransform>().offsetMax.y >= 2 * cost)
            {
                //subtract MP cost on cast
                mpT.GetComponent<RectTransform>().offsetMax =
                    new Vector2(mpT.GetComponent<RectTransform>().offsetMax.x, mpT.GetComponent<RectTransform>().offsetMax.y + cost);

                //cast, disable casting, start cooldown
                canCast = false;
                StartCoroutine("Cooldown");
                //set the cooldown meter to 0
                cdT.GetComponent<RectTransform>().offsetMax =
                    new Vector2(cdT.GetComponent<RectTransform>().offsetMax.x, -200);
            }
        }

        /*if (canCast)
        {
            Debug.Log("Can Cast");
        }*/
    }

    void Regen()
    {
        //actively resize the MP bar as MP regens. I don't know what the 100 is or why it works. If the bar gets resized, try half the new height to check.
        if (mpT.GetComponent<RectTransform>().offsetMax.y < 100)
        {
            //Debug.Log("Regenerating...");
            mpT.GetComponent<RectTransform>().offsetMax =
                new Vector2(mpT.GetComponent<RectTransform>().offsetMax.x, mpT.GetComponent<RectTransform>().offsetMax.y + 4);
        }
    }

    IEnumerator Cooldown()
    {
        for (float i = cooldown; i > -cooldown; i -= 1)
        {
            //Debug.Log(i);
            //increase the meter again
            cdT.GetComponent<RectTransform>().offsetMax =
                new Vector2(cdT.GetComponent<RectTransform>().offsetMax.x, -i);
            if (i <= -cooldown + 1)
            {
                canCast = true;
            }
            yield return null;
        }
    }
}
