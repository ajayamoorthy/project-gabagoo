using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateImg : MonoBehaviour
{

    public Image image;
    public Sprite[] images;
    public float delay = 0.2f;
    int index = 0;

    void Start () 
    {
        image = GetComponent<Image>();
        StartCoroutine(UpdateImg());
    }

    IEnumerator UpdateImg()
    {
        while(true) {
            yield return new WaitForSeconds(delay);
            if(index >= images.Length) {
                index = 0;
            }
            image.sprite = images[index];
            index++;
        }

    }

}
