using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject roadObject; // drag your stretched road sprite here
    public float roadWidth;       // global width value
    public float carSpeed;
    public float zombieSpeed;

    // Progress Bar
    public float progress = 100f;
    public float maxProgress = 100f;
    public float gameTime = 45f;

    public Slider progressBar;
    public Text timerText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }


    // void Update()
    // {
    //     if (gameEnded) return;

    //     gameTime -= Time.deltaTime;
    //     timerText.text = Mathf.Ceil(gameTime).ToString();

    //     if (progress <= 0)
    //     {
    //         GameOver();
    //     }

    //     if (gameTime <= 0 && progress > 0)
    //     {
    //         Debug.Log;
    //     }

    //     progressBar.value = progress / maxProgress;
    // }

    void Start()
    {
        if (roadObject != null)
        {
            // get the width of the road
            SpriteRenderer sr = roadObject.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                roadWidth = sr.bounds.size.x;
            }
        }
    }


    public void DecreaseProgress(float amount)
    {
        progress = Mathf.Max(0, progress - amount);  // decrease progress safely

    // Update progress bar
        if (progressBar != null)
        progressBar.value = progress / maxProgress;

    }

    public void IncreaseProgress(float amount)
    {
        Debug.Log("increasing progress");
    }
    

}
