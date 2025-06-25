using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class RoadItemsMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get car speed from game mahager
        speed = GameManager.Instance.carSpeed;

        // Move object down opposite car speed
        transform.position += Vector3.down * speed * Time.deltaTime;

        // when item reaches the bottom of the screen, move it a random value obove camera view
        // Get bottom and top Y bounds of the camera 
        float camHeight = Camera.main.orthographicSize;
        float camY = Camera.main.transform.position.y;
        float bottomY = camY - camHeight;
        float topY = camY + camHeight;

        // When below the bottom, reset above
        if (transform.position.y < bottomY)
        {
            float halfRoad = GameManager.Instance.roadWidth / 2f;
            float randomX = Random.Range(-halfRoad, halfRoad);

            transform.position = new Vector3(randomX, topY + 1f, transform.position.z); // +1 so it spawns just above view
        }
    }
}
