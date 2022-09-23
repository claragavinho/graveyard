using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public Transform player;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;
    string currentScene;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        currentScene = SceneManager.GetActiveScene().name;
    }




    private void RestartIfPlayerHit(GameObject collidingObj)
    {

        if (collidingObj.tag == "Player") //Is the object we collided with is the player
        {
            // Debug.Log("Restarting"); 
            SceneManager.LoadScene(currentScene); //reload the level, as 'currentscene' refers to the one we're already in
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;

        direction.Normalize();
        movement = direction;



    }

    void FixedUpdate()
    {

        moveCharacter(movement);

    }

    void moveCharacter(Vector2 direction)
    {

        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

    }

    #region Collision Detection
    void OnTriggerEnter2D(Collider2D other)
    {
        RestartIfPlayerHit(other.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RestartIfPlayerHit(other.gameObject);
        if (other.gameObject.tag == "ground")
        {
            Debug.Log("A");
            Destroy(this.gameObject);
        }
    }




    #endregion
}


