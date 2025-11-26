using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool DoPooling = true;
    private static GameManager Instance { get; set; }

    private int playerLevel;
    private int PlayerLevel
    {
        get => playerLevel;
        set => playerLevel = value < 0 ? 0 : value;
    }
    
    public static Vector3 PlayerPosition;
    
    public static int PlayerScore;

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