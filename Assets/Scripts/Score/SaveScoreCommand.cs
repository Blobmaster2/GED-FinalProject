using UnityEngine;

namespace Score
{
    public class SaveScoreCommand : ICommand
    {
        private readonly int score;
        private readonly string playerName;

        public SaveScoreCommand(int score, string playerName)
        {
            this.score = score;
            this.playerName = playerName;
            this.playerName = "Player1";
        }

        public void Execute()
        {
            ScoreHistorySaver.SaveRun(score, playerName);
            Debug.Log($"[Command] Saved score {score} for {playerName}");
        }
    }
}
