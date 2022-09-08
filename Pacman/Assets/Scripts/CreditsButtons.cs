using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButtons : MonoBehaviour
{   
    public void BackButton()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
