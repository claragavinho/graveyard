using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handSpawner : MonoBehaviour
{
    public GameObject hand;

    public float maxX = 10;
    public float maxY = 10;

    public float timeWait;


    void Start()
    {
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {


    }
    IEnumerator waiter()
    {
        while (true)
        {
            SpawnHand();

            yield return new WaitForSecondsRealtime(timeWait);
        }

    }

    void SpawnHand()
    {
        float spawnY = Random.Range(0, maxY);
        float spawnX = Random.Range(0, maxX);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        Debug.Log(spawnPosition);
        Instantiate(hand, spawnPosition, Quaternion.identity);
    }
}
