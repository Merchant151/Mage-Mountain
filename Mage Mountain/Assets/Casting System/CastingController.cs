using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastingController : MonoBehaviour
{
    GameObject orb;
    RawImage mpT;
    RawImage cdT;
    RawImage eHP, pHP;

    float cost, regenRate, cooldown;

    bool canCast;

    PlayerMovement shootScript;
    EnemyController enemyC;
    float enemyHP, playerHP;

    int selectedSpell;
    Image back1, back2, back3;

    AudioSource aSource;
    public AudioClip ice, fire, lightning;

    // Start is called before the first frame update
    void Start()
    {

        aSource = GetComponent<AudioSource>();

        orb = transform.Find("Orb").gameObject;
        mpT = GameObject.Find("MPFront").GetComponent<RawImage>();
        cdT = GameObject.Find("CooldownFront").GetComponent<RawImage>();

        eHP = GameObject.Find("EnemyHPFront").GetComponent<RawImage>();
        pHP = GameObject.Find("PlayerHPFront").GetComponent<RawImage>();

        shootScript = transform.root.GetComponent<PlayerMovement>();
        selectedSpell = 0;

        enemyC = GameObject.Find("Enemy").GetComponent<EnemyController>();
        enemyHP = enemyC.health;
        playerHP = shootScript.health;

        back1 = GameObject.Find("Select1").GetComponent<Image>();
        back2 = GameObject.Find("Select2").GetComponent<Image>();
        back3 = GameObject.Find("Select3").GetComponent<Image>();

        cost = -40;
        cooldown = 100;
        canCast = true;
        regenRate = 2;

        InvokeRepeating("Regen", .1f, regenRate);
        orb.GetComponent<Renderer>().material.color = new Color(1, .5f, .2f, 1); //this orange
    }

    // Update is called once per frame
    void Update()
    {
        //update enemy health - does not look right currently
        enemyHP = enemyC.health;
        eHP.GetComponent<RectTransform>().offsetMax =
            new Vector2(eHP.rectTransform.offsetMax.x, enemyHP);

        //update player health - same issue as above
        playerHP = shootScript.health;
        pHP.GetComponent<RectTransform>().offsetMax =
            new Vector2(pHP.rectTransform.offsetMax.x, playerHP);

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
                if (selectedSpell == 0)
                {
                    aSource.PlayOneShot(fire);
                }
                else if (selectedSpell == 1)
                {
                    aSource.PlayOneShot(ice);
                }
                else if(selectedSpell == 2)
                {
                    aSource.PlayOneShot(fire);
                }
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
        for (float i = cooldown; i > -cooldown; i -= 1.5f)
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
