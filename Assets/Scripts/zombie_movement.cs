using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Ok so zombie movement will be equal to car movement from the start. Then the vertical movement of the car will be
    // zombie speed minus car speed
    private float carSpeed;
    private float zombieSpeed;
    private float relativeSpeed; // thanks Einstein 

    private float normalZombieSpeed = 2f;
    private float boostZompieSpeed = 6f;
    private float boostDuration = 4f;

    private bool isBoosted = false;

    void Start()
    {
        zombieSpeed = normalZombieSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        carSpeed = GameManager.Instance.carSpeed;
        // zombieSpeed = GameManager.Instance.zombieSpeed;

        relativeSpeed = zombieSpeed - carSpeed;

        // moving zombie based on relative speed
        transform.position += Vector3.down * relativeSpeed * Time.deltaTime;

        Debug.Log($"Zombie speed: {zombieSpeed}, CarSpeed: {carSpeed}, RelativeSpeed: {relativeSpeed}");
    }

    public void BoostZombie(float duration, float newSpeed)
    {
        if (!isBoosted)
            StartCoroutine(Boost(duration, newSpeed));
    }

    private System.Collections.IEnumerator Boost(float duration, float newSpeed)
    {
        isBoosted = true;
        zombieSpeed = newSpeed;

        yield return new WaitForSeconds(duration);

        zombieSpeed = normalZombieSpeed;
        isBoosted = false;
    }
}

