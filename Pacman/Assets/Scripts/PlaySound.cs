using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioClip introSound;

    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(introSound);
    }

}
