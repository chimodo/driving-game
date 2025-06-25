using UnityEngine;

public class game_manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject roadObject; // drag your stretched road sprite here
    public float roadWidth;       // global width value
    public float carSpeed;
    public float zombieSpeed;


    public static game_manager Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
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
}
