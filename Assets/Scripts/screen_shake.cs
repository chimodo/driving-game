using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance;

    private Vector3 originalPos;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.2f;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void OnEnable() {
        originalPos = transform.localPosition;
    }

    void Update() {
        if (shakeDuration > 0) {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime;
        } else {
            transform.localPosition = originalPos;
        }
    }

    public void Shake(float duration, float magnitude) {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }
}

