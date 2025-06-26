using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance;

    private Vector3 originalPos;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.2f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("ScreenShake Instance assigned");
        }
        else
        {
            Debug.LogWarning("Another ScreenShake exists — destroying");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPos + (Vector3)(Random.insideUnitCircle * shakeMagnitude);
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPos;
        }
    }

    public void Shake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        Debug.Log($"Shake triggered: duration={duration}, magnitude={magnitude}");
    }
}
