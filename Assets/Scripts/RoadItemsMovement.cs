using UnityEngine;

public class RoadItemsMovement : MonoBehaviour
{
    private float speed;

    void Update()
    {
        speed = GameManager.Instance.carSpeed;
        // prevent that bug
        if (float.IsNaN(speed))
        {
            return;
        }

        transform.position += Vector3.down * speed * Time.deltaTime;

        // Recycle logic
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
