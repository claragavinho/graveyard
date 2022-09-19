using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingChallenge : MonoBehaviour
{

        private int a = 5;
        private int b = 2; 
        private int result;
    // Start is called before the first frame update
    void Start()

    {
        result = a + b;

        Debug.Log(result);
    
        // add two int variables
        // print to console
        // CHALLENGE: When the player hits an input key, add a random number to the sum and print to console.
        // Random.Range(0,10);
        // SUPER CHALLENGE: Using a FOR loop, print to console all numbers from 1 to 100.
        // for(int i = 0; i < 100; i++){ };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
