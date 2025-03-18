using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpLevels : MonoBehaviour
{
    public int sceneLoadIndex;

    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter(Collider other) {
        print("Trigger Entered");
        
        // Could use other.GetComponent<Player>() to see if the game object has a Player component
        // Tags work too. Maybe some players have different script components?
        if(other.tag == "Player") {
            // Player entered, so move level
            print("Switching Scene to " + sceneLoadIndex);
            SceneManager.LoadScene(sceneLoadIndex, LoadSceneMode.Single);
        }
    }
}
