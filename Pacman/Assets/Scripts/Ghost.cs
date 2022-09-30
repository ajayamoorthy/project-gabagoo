using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Movement))]

public class Ghost : MonoBehaviour
{
    public AudioClip ghostSound;
    private AudioSource audio;

    public Movement movement { get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }
    public GhostBehavior initialBehavior;
    public Transform target;
    public int points = 200;

    private void Awake()
    {
        audio = transform.GetComponent<AudioSource>();
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<GhostHome>();
        this.scatter = GetComponent<GhostScatter>();
        this.chase = GetComponent<GhostChase>();
        this.frightened = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();
        
        if(this.home != this.initialBehavior) {
            this.home.Disable();
        }

        if(this.initialBehavior != null) {
            this.initialBehavior.Enable();
        }
    }

    public void SetPosition(Vector3 position)
    {
        position.z = transform.position.z;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name=="PacmanCo-Op")
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
                if(this.frightened.enabled) {
                    audio.PlayOneShot(ghostSound);
                    FindObjectOfType<GameManagerCoOp>().GhostEaten(this);
                } else {
                    FindObjectOfType<GameManagerCoOp>().PacmanEaten();
                }
            }
        }
        else{
            if(collision.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
                if(this.frightened.enabled) {
                    audio.PlayOneShot(ghostSound);
                    FindObjectOfType<GameManager>().GhostEaten(this);
                } else {
                    FindObjectOfType<GameManager>().PacmanEaten();
                }
            }
        }
    }
}
