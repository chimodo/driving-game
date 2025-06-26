using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float turnSpeed;
    float movementHorizontal;

    private float currentSpeed = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");

        // Move the car left/right
        transform.position += Vector3.right * movementHorizontal * turnSpeed * Time.deltaTime;

        // Clamp car's X position to stay within the road
        float halfRoad = GameManager.Instance.roadWidth / 2f;
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -halfRoad, halfRoad);
        transform.position = pos;

        // Tilt logic
        float maxTiltAngle = 15f;
        float smoothSpeed = 5f;
        Quaternion targetRotation;

        if (Mathf.Abs(movementHorizontal) < 0.01f)
        {
            // No input → return to upright
            targetRotation = Quaternion.identity;
        }
        else
        {
            // Tilt left or right
            float targetZRotation = -movementHorizontal * maxTiltAngle;
            targetRotation = Quaternion.Euler(0, 0, targetZRotation);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }

    

}

