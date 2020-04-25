using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherMan : MonoBehaviour
{
    //maincameratransform 
    //snow object
    //rain object
    //wind object

    int mode;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        //getmaincameratransfrom
        //get rain
        //get wind
        //get snow

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
        }
        
        if (mode == 0)
        {
            //Sunny Mode
        }else if (mode == 1)
        {
            //rainy Mode
        }else if (mode == 2)
        {
            //Snowy Mode
        
        }else if (mode == 3)
        {
            //Windy mode
        }
        
    }
}
