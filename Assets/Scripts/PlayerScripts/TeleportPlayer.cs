using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPlayer : MonoBehaviour
{
    public Transform player;
    public Transform platform;
    public float detectionRadius = 1000f;

    private Vector3 playerInitialPosition;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        if (player != null)
        {
            playerInitialPosition = player.position; // Store the initial position of the player
        }

        if (platform == null)
        {
            platform = GameObject.FindWithTag("Platform").transform;
        }
    }

    private void Update()
    {
        if (player != null && platform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRadius)
            {
                // Player within detection radius.
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResetScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.position.y < platform.position.y)
            {
                // Did not collide
            }
        }
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
