using UnityEngine;

public class BunkerArrival : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached the bunker! You win!");

            // Optional: Stop gameplay
            GameManager.Instance.carSpeed = 0f;
            GameManager.Instance.zombieSpeed = 0f;
            //GameManager.Instance.carRb.velocity = Vector2.zero;

            
            other.GetComponent<CarController>().enabled = false;
            GameManager.Instance.EndGame(true); // Player won

            // Optional: Load Win Scene
            // SceneManager.LoadScene("WinScene");

            // Optional: Show win UI
            // winPanel.SetActive(true);

            // Optional: Freeze game
            // Time.timeScale = 0;
        }
    }
}
