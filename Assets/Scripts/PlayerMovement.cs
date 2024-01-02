using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    public Text highScoreText;

    bool alive = true;

    public float speed = 5;
    public float jumpForce = 7;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    // Add this line to get a reference to the Animator component
    Animator animator;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("isWalking", false);
            animator.SetBool("isJumbing", true);
            

            gameManager.jumpingSound.Play();
        }
        else
        {
            animator.SetBool("isJumbing", false);
            animator.SetBool("isWalking", true);

        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        // Set isWalking to false when the character dies
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumbing", false);
        animator.SetBool("isDie", true);
        int currentScore = gameManager.GetScore();

        // Check if the current score is higher than the high score
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            // Update the high score
            PlayerPrefs.SetInt("HighScore", currentScore);
        }

        // Retrieve the high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Display the high score
        highScoreText.text = "HighScore:" + highScore;
        gameManager.gameOver.text = "Game over";
        gameManager.DieSound.Play();
        // yield return new WaitForSeconds(3.0f);

        Invoke("LoadDieScene", 3.0f);
    }

    void LoadDieScene()
    {
        SceneManager.LoadScene("Die");
    }

    void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Camera.main.transform.position = new Vector3(0, 7, 0); // Replace with your camera's initial position
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Add this method to initialize the animator reference
    void Start()
    {
        animator = GetComponent<Animator>();
        // Set isWalking to true at the start of the game
        animator.SetBool("isWalking", true);
    }
}




/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
   public GameManager gameManager;
    public Text highScoreText;

    bool alive = true;

    public float speed = 5;
    public float jumpForce = 7;
    [SerializeField] Rigidbody rb;
    
    
    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

  
     

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            gameManager.jumpingSound.Play(); 
        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {

        alive = false;
        int currentScore = gameManager.GetScore();

        // Check if the current score is higher than the high score
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            // Update the high score
            PlayerPrefs.SetInt("HighScore", currentScore);
        }

        // Retrieve the high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Display the high score
        highScoreText.text = "HighScore:" + highScore;
        gameManager.gameOver.text = "Game over";
        gameManager.DieSound.Play();
        Invoke("Restart", 5);






    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

*/