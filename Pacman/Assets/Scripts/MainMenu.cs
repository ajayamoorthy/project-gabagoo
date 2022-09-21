using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame() {
        SceneManager.LoadScene("Pacman");
    }

    public void QuitGame() {
        Application.Quit();
        //SceneManager.LoadScene(0);
    }
    
    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void Notes() {
        SceneManager.LoadScene("VersionNotes");
    }

}
