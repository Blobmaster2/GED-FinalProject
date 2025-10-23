using UnityEngine;
using Random = UnityEngine.Random;

namespace Score
{
    public class ScoreTest : MonoBehaviour
    {
        private CommandInvoker commandInvoker;

        private void Awake()
        {
            commandInvoker = gameObject.AddComponent<CommandInvoker>();
        }

        public void SaveScore(int score)
        {
            score = Random.Range(0, 100);
            commandInvoker.ExecuteCommand(new SaveScoreCommand(score, "player1"));
        }

        public void ShowHistorySummary()
        {
            Debug.Log(ScoreHistorySaver.TryLoadHistory(out var history)
                ? $"Runs stored: {history.runs.Count}, Best: {history.bestScore}, Last saved: {history.lastSaved}"
                : "No history saved yet.");
        }
        
        public void DeleteAllScores()
        {
            commandInvoker.ExecuteCommand(new DeleteScoreFileCommand());
        }
    }
}