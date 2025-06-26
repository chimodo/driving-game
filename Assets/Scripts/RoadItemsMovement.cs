using UnityEngine;

public class RoadItemsMovement : MonoBehaviour
{
    private float speed;

    void Update()
    {
        // Base car speed from GameManager
        speed = GameManager.Instance.carSpeed;

        // Get the car's current vertical velocity from Rigidbody2D
        float carVelocityY = GameManager.Instance.carRb.velocity.y;

        // Calculate relative speed for road items
        float relativeSpeed = speed - carVelocityY;
        Debug.Log(carVelocityY);

        // Move road item down at relative speed
        transform.position += Vector3.down * relativeSpeed * Time.deltaTime;

        // Recycle objects when off screen (optional but recommended)
        float camHeight = Camera.main.orthographicSize;
        float camY = Camera.main.transform.position.y;
        float bottomY = camY - camHeight;
        float topY = camY + camHeight;

        if (transform.position.y < bottomY)
        {
            float halfRoad = GameManager.Instance.roadWidth / 2f;
            float randomX = Random.Range(-halfRoad, halfRoad);

            transform.position = new Vector3(randomX, topY + 1f, transform.position.z);
        }
    }
}
