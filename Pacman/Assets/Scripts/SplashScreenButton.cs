using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenButton : MonoBehaviour
{
    public void ToStartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
