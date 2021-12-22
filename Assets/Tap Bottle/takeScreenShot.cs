﻿using UnityEngine;

public class takeScreenShot : MonoBehaviour
{

    public KeyCode key = KeyCode.G;

    void Start()
    {
        //DontDestroyOnLoad (gameObject);
    }

    string resolution;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            resolution = "" + Screen.width + "X" + Screen.height;
            ScreenCapture.CaptureScreenshot(Application.productName + "_ScreenShot-" + resolution + "-" + PlayerPrefs.GetInt("number", 0) + ".png",1);
            PlayerPrefs.SetInt("number", PlayerPrefs.GetInt("number", 0) + 1);
            Debug.Log ("takenShot with " + resolution);

        }

    }
}
