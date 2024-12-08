using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePush;
using Unity.VisualScripting.Antlr3.Runtime;
using System;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        GP_Game.OnPause += Paused;
        GP_Game.OnResume += Resumed;
    }

    void OnDisable()
    {
        GP_Game.OnPause -= Paused;
        GP_Game.OnResume -= Resumed;
    }

    private void Paused()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    private void Resumed()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
