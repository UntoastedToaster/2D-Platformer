using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOPENER : MonoBehaviour
{
    public string sceneName;
 public void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
