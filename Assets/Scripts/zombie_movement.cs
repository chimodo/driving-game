using UnityEngine;

public class zombie_movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Ok so zombie movement will be equal to car movement from the start. Then the vertical movement of the car will be
    // zombie speed minus car speed
    private float carSpeed;
    private float zombieSpeed;
    private float relativeSpeed; // thanks Einstein

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carSpeed = game_manager.Instance.carSpeed;
        zombieSpeed = game_manager.Instance.zombieSpeed;

        relativeSpeed = zombieSpeed - carSpeed;
        transform.position += Vector3.down * relativeSpeed * Time.deltaTime;
    }
}
