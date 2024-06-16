using UnityEngine;
using UnityEngine.UI; // Ensure you have this using statement

public class FPSCounter : MonoBehaviour
{
    public Text uiText; // Use Text instead of GUIText

    void Start()
    {
        uiText.text = "FPS: " + (1.0f / Time.deltaTime).ToString("F2");
    }

    void Update()
    {
        uiText.text = "FPS: " + (1.0f / Time.deltaTime).ToString("F2");
    }
}
