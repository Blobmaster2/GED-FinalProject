using UnityEngine;

namespace Score
{
    public class DeleteScoreFileCommand : ICommand
    {
        public void Execute()
        {
            ScoreHistorySaver.DeleteHistory();
            Debug.Log("[Command] Deleted score history file");
        }
    }
}