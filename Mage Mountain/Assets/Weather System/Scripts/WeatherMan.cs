using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherMan : MonoBehaviour
{
    int mode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         *Sunny = 0
         *Rainy = 1
         *Snowy = 2
         *Windy = 3
         */
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
