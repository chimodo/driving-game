using UnityEngine;
using System.Collections;

public class Pothole : MonoBehaviour
{

    public float slowDuration = 3f;

    public float slowSpeed = 1f;

    public float loseProgres = 10f;

    // void Start()
    // {
    //     ScreenShake.Instance.Shake(1f, 0.5f);
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<CarController>().SlowDown(slowDuration, slowSpeed);
            //GameManager.Instance.DecreaseProgress(loseProgres);
            StartCoroutine(SlowCarDown());
            ScreenShake.Instance.Shake(2f, 0.1f);
            
            // slow down the car
            
        }
    }

    private IEnumerator SlowCarDown()
    {
        float originalSpeed = GameManager.Instance.carSpeed;
        GameManager.Instance.carSpeed = slowSpeed;

        yield return new WaitForSeconds(slowDuration);

        GameManager.Instance.carSpeed = originalSpeed;
    }
}
