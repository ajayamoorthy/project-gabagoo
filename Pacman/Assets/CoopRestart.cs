using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoopRestart : MonoBehaviour
{
    public void RestartCoop()
    {
        SceneManager.LoadScene("PacmanCo-Op");
    }
}
