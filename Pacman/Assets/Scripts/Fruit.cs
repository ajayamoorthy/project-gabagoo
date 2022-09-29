using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class Fruit : MonoBehaviour
{
    
    public int points = 500;

    protected virtual void Eat()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name=="PacmanCo-Op")
        {
            FindObjectOfType<GameManagerCoOp>().FruitEaten(this);
        }
        else{
            FindObjectOfType<GameManager>().FruitEaten(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            Eat();
        }
    }

}
