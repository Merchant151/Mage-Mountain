using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this keeps the game management scripts active through all scenes
public class DDOL : MonoBehaviour
{
    public void Awake()
    {
        //keeps the object across scenes
        DontDestroyOnLoad(gameObject);

        //loads preload scene by default
        GameObject check = GameObject.Find("__app");
        if (check == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("_preload");
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
