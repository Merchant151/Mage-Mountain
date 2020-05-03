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

    PlayerMovement shootScript;

    int selectedSpell;
    Image back1, back2, back3;

    // Start is called before the first frame update
    void Start()
    {
        orb = transform.Find("Orb").gameObject;
        mpT = GameObject.Find("MPFront").GetComponent<RawImage>();
        cdT = GameObject.Find("CooldownFront").GetComponent<RawImage>();

        shootScript = transform.root.GetComponent<PlayerMovement>();
        selectedSpell = 0;
        back1 = GameObject.Find("Select1").GetComponent<Image>();
        back2 = GameObject.Find("Select2").GetComponent<Image>();
        back3 = GameObject.Find("Select3").GetComponent<Image>();

        cost = -40;
        cooldown = 100;
        canCast = true;
        regenRate = 1;

        InvokeRepeating("Regen", 2, regenRate);
        orb.GetComponent<Renderer>().material.color = new Color(1, .5f, .2f, 1); //this orange
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canCast)
        {
            //change color of staff orb. need to move later
            //orb.GetComponent<Renderer>().material.color = Random.ColorHSV();

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

                //shoot
                shootScript.shoot(shootScript.power, selectedSpell);
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            //cycle spells
            if (selectedSpell != 2)
            {
                selectedSpell++;
            }
            else
            {
                selectedSpell = 0;
            }
            //function for updating ui
            ShowSelected(selectedSpell);
        }

        /*if (canCast)
        {
            Debug.Log("Can Cast");
        }*/
    }

    void ShowSelected(int selected)
    {
        if (selected == 0)
        {
            back1.enabled = true;
            back2.enabled = false;
            back3.enabled = false;
            orb.GetComponent<Renderer>().material.color = new Color(.8f, .5f, .2f, 1); //orange
        }
        else if (selected == 1)
        {
            back1.enabled = false;
            back2.enabled = true;
            back3.enabled = false;
            orb.GetComponent<Renderer>().material.color = new Color(.3f, .3f, .8f, 1); //pale blue
        }
        else if (selected == 2)
        {
            back1.enabled = false;
            back2.enabled = false;
            back3.enabled = true;
            orb.GetComponent<Renderer>().material.color = new Color(.8f, .3f, 1, 1); //purple
        }
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
