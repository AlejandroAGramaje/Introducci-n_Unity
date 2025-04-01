using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObject : MonoBehaviour
{
    void Update()
    {
        if (LevelManager.numInitialBlocks == 0)
        {
            // Reinicia la escena actual
            UIManager.instance.WinGame();
        }
    }
}
