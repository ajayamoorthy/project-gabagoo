using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlickeringLight : MonoBehaviour
{

    public Image image;

    void Start () 
    {
          image = GetComponent<Image>();
    }

    void Update()
    {
        StartCoroutine(UpdateColor());
    }

    IEnumerator UpdateColor()
    {
        float delay = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(delay);
        var tempColor = image.color;
        tempColor.a = Random.Range(0f, 0.5f);
        image.color = tempColor;
    }

}
