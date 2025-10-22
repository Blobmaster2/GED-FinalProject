using UnityEngine;

namespace Score
{
    public class ScoreTest : MonoBehaviour
    {
        public void Save()
        {
            ScoreHistorySaver.SaveRun(Random.Range(5, 10), "Player1");
        }

        public void ShowHistorySummary()
        {
            if (ScoreHistorySaver.TryLoadHistory(out var history))
            {
                Debug.Log(
                    $"Runs stored: {history.runs.Count}, Best: {history.bestScore}, Last saved: {history.lastSaved}");
                if (ScoreHistorySaver.TryGetLastRun(out var last))
                {
                    Debug.Log($"Last run: {last.score} by {last.playerName} at {last.savedAt}");
                }
            }
            else
            {
                Debug.Log("No history saved yet.");
            }
        }
        
        public void ResetAllScores()
        {
            ScoreHistorySaver.DeleteHistory();
            Debug.Log("All score history deleted!");
        }
    }
}