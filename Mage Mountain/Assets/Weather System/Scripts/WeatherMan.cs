using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherMan : MonoBehaviour
{
    //maincameratransform 
    Transform camTran;
    //snow object
    GameObject snow;
    //rain object
    GameObject rain;
    //wind object ???

    int mode;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        //getmaincameratransfrom
        camTran = Camera.main.transform;
        //get rain
        rain = GameObject.Find("Rain");
        rain.SetActive(false);
        //get wind
        //get snow
        snow = GameObject.Find("Snow");
        snow.SetActive(false);


        timer = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //Debug.Log("Current weather mode:"+mode);

        //change weather
        if (timer <= 0)
        {
            timer = 30f;
            mode = Random.Range(0,4);
            rain.SetActive(false);
            snow.SetActive(false);
            Debug.Log("Current weather mode:" + mode);

        }
           
        if (mode == 0)
        {
            //Sunny Mode
        }else if (mode == 1)
        {
            //rainy Mode
            rain.SetActive(true);
            Debug.Log("it should be raining ");
            rain.transform.position = new Vector3(camTran.position.x, rain.transform.position.y, camTran.position.z);
        }else if (mode == 2)
        {
            //Snowy Mode
            snow.SetActive(true);
            snow.transform.position = new Vector3(camTran.position.x, snow.transform.position.y, camTran.position.z);
        }
        else if (mode == 3)
        {
            //Windy mode
        }
        
    }
}
