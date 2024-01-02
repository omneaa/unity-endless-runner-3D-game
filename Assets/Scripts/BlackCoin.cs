using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlackCoin : MonoBehaviour
{

    [SerializeField] float turnSpeed = 90f;
    [SerializeField] AudioClip coinSound;
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Double the player's score
        GameManager.inst.DoubleScore();
        
      

        // Destroy this black coin object
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
    private void Start()
    {
        
    }

}

