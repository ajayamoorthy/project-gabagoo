using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;


    public float delay = 2;
    public string NewLevel;

    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }
 
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(NewLevel);
    }


    // void Update()
    // {
    //     if(Input.GetKeyDown("space")) {
    //         LoadNextLevel();
    //     }
    // }

    // public void LoadNextLevel()
    // {
    //     StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    // }

    // IEnumerator LoadLevel(int levelIndex)
    // {
    //     transition.SetTrigger("Start");
    //     yield return new WaitForSeconds(transitionTime);
    //     SceneManager.LoadScene(levelIndex);
    // }

}
