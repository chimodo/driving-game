using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI winLoseText;
    private bool gameEnded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject roadObject; // drag your stretched road sprite here
    public float roadWidth;       // global width value
    public float carSpeed;
    public float zombieSpeed;
    public Rigidbody2D carRb;

    private Vector2 lastPosition;
    public float currentVerticalSpeed;

    // manage sound
    [SerializeField] public AudioSource backgroundMusic;
    [SerializeField] public AudioClip loseSoundClip;

    // Progress Bar
    //public float progress = 100f;
    //public float maxProgress = 100f;
    //public float gameTime = 45f;

    //public Slider progressBar;
    //public Text timerText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        lastPosition = carRb.position;
    }


    void Update()
    {
        // track current car position
        Vector2 currentPosition = carRb.position;
        currentVerticalSpeed = (currentPosition.y - lastPosition.y) / Time.deltaTime;
        lastPosition = currentPosition;
    }

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


    //public void DecreaseProgress(float amount)
    //{
    //    progress = Mathf.Max(0, progress - amount);  // decrease progress safely

    //// Update progress bar
    //    if (progressBar != null)
    //    progressBar.value = progress / maxProgress;

    //}

    //public void IncreaseProgress(float amount)
    //{
    //    Debug.Log("increasing progress");
    //}

    public void EndGame(bool didWin)
    {
        if (gameEnded) return;
        gameEnded = true;

        Time.timeScale = 0f; // Pause game

        // Stop background music immediately
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        if (!didWin && loseSoundClip != null)
        {
            // Play lose sound once (use a separate AudioSource if needed)
            AudioSource.PlayClipAtPoint(loseSoundClip, Camera.main.transform.position);
        }

        winLoseText.text = didWin ? "You made it to the bunker!" : "The Zombies ate your brains!";
        winLoseText.color = didWin ? Color.green : Color.red;
        winLoseText.gameObject.SetActive(true);

        // Optional: disable player input, music, or other systems here
    }


}
