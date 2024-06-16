using UnityEngine;
using UnityEngine.UI; // Ensure you have this using statement

public class ForcedReset : MonoBehaviour
{
    public Image uiImage; // Use Image instead of GUITexture

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            uiImage.enabled = !uiImage.enabled;
    }
}
