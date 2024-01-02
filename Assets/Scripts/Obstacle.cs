using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Obstacle : MonoBehaviour
{

    PlayerMovement playerMovement;
    public float speed = 2.0f; // Speed at which the obstacle moves
    private Vector3 startPos;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        startPos = transform.position; // Remember the start position of the obstacle
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Kill the player
            playerMovement.Die();
        }
    }

    private void Update()
    {
        // Move the obstacle left and right over time
        transform.position = startPos + new Vector3(Mathf.Sin(Time.time * speed), 0, 0);
    }
}



/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {

    PlayerMovement playerMovement;

	private void Start () {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
	}

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.name == "Player") {
            // Kill the player
            playerMovement.Die();
        }
    }

    private void Update () {
	
	}
}*/