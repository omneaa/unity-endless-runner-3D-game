

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class begin : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public AudioSource StartSound;
    //public string userName;

    public void load()
    {
        // userName = nameInputField.text;
        PlayerPrefs.SetString("UserName", nameInputField.text);
        Debug.Log("User Name Saved: " + nameInputField.text);
        SceneManager.LoadScene("Scenes/SampleScene");
       // SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void quit()
    {

        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();

    }
    public void start()
    {
        StartSound.Play();
    }


}

