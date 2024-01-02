using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour {

    [SerializeField] float turnSpeed = 90f;
    [SerializeField] AudioClip coinSound;
    AudioSource audioSource;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player") {
            return;
        }
        
        
       // audioSource.PlayOneShot(coinSound);
        GameManager.inst.IncrementScore();
        audioSource.PlayOneShot(coinSound);
        Destroy(gameObject);
    }

    private void Start () {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

	private void Update () {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
	}
}