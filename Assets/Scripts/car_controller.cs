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

        transform.position += Vector3.right * movementHorizontal * turnSpeed * Time.deltaTime;
        //transform.rotation // i want the car to have a tilting effect as it turns

        // Move forward using currentSpeed
        // transform.position += Vector3.up * currentSpeed * Time.deltaTime;



        //vibe code for tilt on car movement
        // Calculate target rotation angle (tilt)
        float maxTiltAngle = 15f; // max degrees to tilt
        // float targetZRotation = -movementHorizontal * maxTiltAngle;

        // Smoothly interpolate to the target rotation
        float smoothSpeed = 5f;

        // Quaternion targetRotation = Quaternion.Euler(0, 0, targetZRotation);
        // transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);

        // Debug.Log("Current Speed: " + currentSpeed);

        // // want car to return upright when its not turning
        // if (Mathf.Abs(movementHorizontal) < 0.01f)
        // {
        //     transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, smoothSpeed * Time.deltaTime);
        // }
        // else
        // {
        //     Quaternion targetRotation = Quaternion.Euler(0, 0, -movementHorizontal * maxTiltAngle);
        //     transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
        // }

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

    public void SlowDown(float duration, float newSpeed)
    {
        StopAllCoroutines();
        StartCoroutine(SlowDownCoroutine(duration, newSpeed));
    }

// Slow downs car
    private System.Collections.IEnumerator SlowDownCoroutine(float duration, float newSpeed)
    {
        Debug.Log("slowing down car");
        float originialSpeed = currentSpeed;
        currentSpeed = newSpeed;
        yield return new WaitForSeconds(duration);
        currentSpeed = originialSpeed;
    }

    public void BounceBack()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, -2f);
    }

}

