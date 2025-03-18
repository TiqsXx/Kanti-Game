
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToWorldMapButton : MonoBehaviour
{
    public int sceneLoadIndex;
public void ReturnToMap()
{
 SceneManager.LoadScene(sceneLoadIndex, LoadSceneMode.Single);
}

}
