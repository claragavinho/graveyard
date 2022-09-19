using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnHit : MonoBehaviour
{
    string currentScene;
    private void Start()
    {
        //we get the current scene name from the SceneManager so this script works for "Level 1", "Level 2" and so on!
        currentScene = SceneManager.GetActiveScene().name;
    }

    private void RestartIfPlayerHit(GameObject collidingObj)
    {
        
        if (collidingObj.tag == "Player") //Is the object we collided with is the player
        {
            Debug.Log("Restarting"); 
            SceneManager.LoadScene(currentScene); //reload the level, as 'currentscene' refers to the one we're already in
        }
    }

    #region Collision Detection
    void OnTriggerEnter2D(Collider2D other)
    {
        RestartIfPlayerHit(other.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RestartIfPlayerHit(other.gameObject);
    }
    #endregion

}
