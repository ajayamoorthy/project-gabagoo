using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    
    public static MusicMenu MusicInstance;

    private void Awake()
    {
        if(MusicInstance != null && MusicInstance!= this) {
            Destroy(this.gameObject);
            return;
        }

        MusicInstance = this;
        DontDestroyOnLoad(this);
    }

}
