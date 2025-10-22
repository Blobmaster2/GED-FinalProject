using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance { get; set; }

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Keep it between scenes
    }
}