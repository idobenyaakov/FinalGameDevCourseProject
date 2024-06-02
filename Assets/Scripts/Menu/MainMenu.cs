using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayableDirector cutsceneDirector; // Reference to the Playable Director component
    public Canvas mainMenuCanvas; // Reference to the Main Menu Canvas

    void Update()
    {
        // Release the mouse cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Make the cursor visible
    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("SelectButton");
        StopBackgroundMusic();
        StartCoroutine(PlayCutsceneAndLoadNextScene());
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

    private void StopBackgroundMusic()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.StopAllSounds();
        }
        else
        {
            Debug.LogWarning("AudioManager not found in the scene.");
        }
    }

    private IEnumerator PlayCutsceneAndLoadNextScene()
    {
        if (cutsceneDirector != null)
        {
            Debug.Log("Playing cutscene...");
            mainMenuCanvas.enabled = false; // Disable the Main Menu Canvas
            cutsceneDirector.gameObject.SetActive(true); // Enable the GameObject with the Playable Director
            cutsceneDirector.Play(); // Play the cutscene Timeline
            yield return new WaitForSeconds((float)cutsceneDirector.duration); // Wait for the duration of the cutscene
        }
        else
        {
            Debug.LogError("Cutscene Director is not assigned.");
        }

        Debug.Log("Cutscene finished, loading next scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene
    }
}
