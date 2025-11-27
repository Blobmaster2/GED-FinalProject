using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Score
{
    public class ScoreTest : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private CommandInvoker commandInvoker;

        private void Awake()
        {
            commandInvoker = gameObject.AddComponent<CommandInvoker>();
        }

        public void SaveScore(int score)
        {
            score = GameManager.PlayerScore;
            commandInvoker.ExecuteCommand(new SaveScoreCommand(score, "player1"));
        }

        public void ShowHistorySummary()
        {
            Debug.Log(ScoreHistorySaver.TryLoadHistory(out var history)
                ? $"Runs stored: {history.runs.Count}, Best: {history.bestScore}, Last saved: {history.lastSaved}"
                : "No history saved yet.");

            scoreText.text = history != null ? $"Best: {history.bestScore}, Last saved: {history.lastSaved}" 
                : "No history saved yet.";
        }
        
        public void DeleteAllScores()
        {
            commandInvoker.ExecuteCommand(new DeleteScoreFileCommand());
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}