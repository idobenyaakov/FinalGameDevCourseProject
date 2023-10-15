using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Update()
    {
        // Release the mouse cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Make the cursor visible
    }
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("SelectButton");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Settings()
    {
        FindObjectOfType<AudioManager>().Play("SelectButton");
    }

    public void ExitGame()
    {
        FindObjectOfType<AudioManager>().Play("SelectButton");
        Application.Quit();
    }
}
