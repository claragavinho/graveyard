using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;
    string currentScene;
    public float speed;
    public Transform startingPoint;
    public Transform colliderZone;
    bool gotGrabbed;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlatformerController>().gameObject;
        rb = this.GetComponent<Rigidbody2D>();
        currentScene = SceneManager.GetActiveScene().name;
        startingPoint = GameObject.Find("startingPoint").transform;
        colliderZone = GameObject.Find("ColliderZone").transform;
    }


    #region Collision Detection

    void OnCollisionEnter2D(Collision2D other)
    {
        gotGrabbed = true;
    
    }

    #endregion


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;

        direction.Normalize();
        movement = direction;


    }

    void FixedUpdate()
    {

        moveCharacter(movement);

        if (gotGrabbed == true){

            Vector2 target = new Vector2(startingPoint.position.x, startingPoint.position.y);
            float step = speed * Time.deltaTime;
            player.GetComponent<Collider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().isKinematic = false;
            player.transform.position = Vector2.Lerp(player.transform.position, startingPoint.transform.position, step);

            if (player.transform.position.x <= colliderZone.position.x){
                
                gotGrabbed = false;
                Destroy(this.gameObject);
                player.GetComponent<Collider2D>().enabled = true;
                player.GetComponent<Rigidbody2D>().isKinematic = false;
                Debug.Log("S");
            }

        }

    }

    void moveCharacter(Vector2 direction)
    {

        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

    }
}


