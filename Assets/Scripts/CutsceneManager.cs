using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public string nextSceneName;

    void Start()
    {
        // Subscribe to the PlayableDirector's stopped event
        playableDirector.stopped += OnPlayableDirectorStopped;
    }

    void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed
        playableDirector.stopped -= OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector director)
    {
        // Check if the stopped director is the one we are managing
        if (director == playableDirector)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
