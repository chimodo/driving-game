using UnityEngine;

public class car_controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float turnSpeed;
    float movementHorizontal;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * movementHorizontal * turnSpeed * Time.deltaTime;
        //transform.rotation // i want the car to have a tilting effect as it turns


        //vibe code for tilt on car movement
            // Calculate target rotation angle (tilt)
        float maxTiltAngle = 15f; // max degrees to tilt
        float targetZRotation = -movementHorizontal * maxTiltAngle;

        // Smoothly interpolate to the target rotation
        float smoothSpeed = 5f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetZRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }
}
