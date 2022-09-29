using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class Pellet : MonoBehaviour
{
    public int points = 10;

    protected virtual void Eat()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name=="PacmanCo-Op")
        {
            FindObjectOfType<GameManagerCoOp>().PelletEaten(this);
        }
        else{
            FindObjectOfType<GameManager>().PelletEaten(this);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            Eat();
        }
    }

}