using UnityEngine;

public class Pothole : MonoBehaviour
{

    public float slowDuration = 2f;

    public float slowSpeed = 0.5f;

    public float loseProgres = 10f;

    // void Start()
    // {
    //     ScreenShake.Instance.Shake(1f, 0.5f);
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CarController>().SlowDown(slowDuration, slowSpeed);
            GameManager.Instance.DecreaseProgress(loseProgres);
            ScreenShake.Instance.Shake(1f, 0.5f);
        }
    }
}
