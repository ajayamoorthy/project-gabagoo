using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerPellet : Pellet
{
    public float duration = 8f;

    protected override void Eat()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name=="PacmanCo-Op")
        {
            FindObjectOfType<GameManagerCoOp>().PowerPelletEaten(this);
        }
        else {
            FindObjectOfType<GameManager>().PowerPelletEaten(this);
        }
        
    }

}
