using UnityEngine;
using System.Collections;

public class HitBlockade : MonoBehaviour
{
    public float slowDuration = 3f;

    public float slowSpeed = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //GameManager.Instance.carSpeed = 0f;
            //GameManager.Instance.carRb.velocity = Vector2.zero;

            StartCoroutine(SlowCarDown());
            ScreenShake.Instance.Shake(1f, 0.1f);

            //ScreenShake.Instance.Shake(2f, 0.1f);

            Debug.Log("Game Over - Hit Blockade");
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
