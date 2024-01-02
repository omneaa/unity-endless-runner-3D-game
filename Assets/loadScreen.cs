using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class loadScreen : MonoBehaviour
{
    //public TMP_InputField nameInputField;
    public AudioSource StartSound;


    public void load()
    {
        // PlayerPrefs.SetString("UserName", nameInputField.text);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Scenes/SampleScene");
        
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
