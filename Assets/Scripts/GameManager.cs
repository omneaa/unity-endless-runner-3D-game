using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    int score;
    int goldCoin;
    int blackCoin;
    public AudioSource GoldCoinSound;
    public AudioSource DieSound;
    public AudioSource BlackCoinSound;
    public AudioSource jumpingSound;
    public static GameManager inst;
    //public loadScreen loadScreen;
    public Text userNameText;
    public Text scoreText;
    public Text goldText;
    public Text blackText;
    public Text gameOver;
    //public Text userName;
    [SerializeField] PlayerMovement playerMovement;
     begin begin;

    public void IncrementScore ()
    {
        score++;
        goldCoin++;

        scoreText.text = "SCORE: " + score;
        goldText.text = "Gold Coins SCORE: " + goldCoin;
        blackText.text = "black Coins SCORE: " + blackCoin;
        GoldCoinSound.Play();
      
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }
    public void DoubleScore()
    {
        blackCoin++;
        score += 2;
        scoreText.text = "Total SCORE: " + score;
        goldText.text = "Gold Coins SCORE: " + goldCoin;
        blackText.text = "Black Coins SCORE: " + blackCoin;
       BlackCoinSound.Play();
    }

    private void Awake ()
    {
        inst = this;
    }

    void Start () {
        string userName = PlayerPrefs.GetString("UserName", "Default Name");
        Debug.Log("User Name Loaded (Start): " + userName);  // Add this line

        // Display the user's name
        userNameText.text = "Hello: " + userName;
    }
    public int GetScore()
    {
        return score;
    }

    private void Update () {
        string userName = PlayerPrefs.GetString("UserName", "Default Name");
        Debug.Log("User Name Loaded (Update): " + userName);
    }
}