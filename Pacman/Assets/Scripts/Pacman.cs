using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Movement))]

public class Pacman : MonoBehaviour
{
    public AudioClip dieSound;
    private AudioSource audio;
    public CameraShake cameraShake;

    public AnimatedSprite deathSequence;
    public SpriteRenderer spriteRenderer { get; private set; }
    public new Collider2D collider { get; private set; }
    public Movement movement { get; private set; }


    private void Awake()
    {
        audio = transform.GetComponent<AudioSource>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.collider = GetComponent<Collider2D>();
        this.movement = GetComponent<Movement>();
        TimerController.instance.BeginTimer();
    }


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) {
            this.movement.SetDirection(Vector2.up);
        }
        else if(Input.GetKeyDown(KeyCode.S)) {
            this.movement.SetDirection(Vector2.down);
        }
        else if(Input.GetKeyDown(KeyCode.A)) {
            this.movement.SetDirection(Vector2.left);
        }
        else if(Input.GetKeyDown(KeyCode.D)) {
            this.movement.SetDirection(Vector2.right);
        }

        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void ResetState()
    {
        this.enabled = true;
        this.spriteRenderer.enabled = true;
        this.collider.enabled = true;
        this.deathSequence.enabled = false;
        this.deathSequence.spriteRenderer.enabled = false;
        this.movement.ResetState();
        this.gameObject.SetActive(true);
    }

    public void DeathSequence()
    {
        StartCoroutine(cameraShake.Shake(.2f, .7f));
        this.enabled = false;
        this.spriteRenderer.enabled = false;
        this.collider.enabled = false;
        this.movement.enabled = false;
        this.deathSequence.enabled = true;
        this.deathSequence.spriteRenderer.enabled = true;
        this.deathSequence.Restart();
        audio.PlayOneShot(dieSound);
    }

}
