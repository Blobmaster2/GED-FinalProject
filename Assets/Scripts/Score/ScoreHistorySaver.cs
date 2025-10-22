using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Score
{
    public static class ScoreHistorySaver
    {
        [Serializable]
        public class ScoreRun
        {
            public string playerName;
            public int score;
            public string savedAt;
            public string runId;
        }

        [Serializable]
        public class ScoreHistory
        {
            public List<ScoreRun> runs = new List<ScoreRun>();
            public int totalRuns;
            public int bestScore;
            public string lastSaved;
        }

        public static void SaveRun(int score, string playerName = "Player")
        {
            var history = LoadOrCreateHistoryInternal();

            var run = new ScoreRun
            {
                playerName = playerName,
                score = score,
                savedAt = DateTime.Now.ToString("G"),
                runId = Guid.NewGuid().ToString("N")
            };

            history.runs.Add(run);

            history.totalRuns = Mathf.Max(history.totalRuns + 1, history.runs.Count);
            history.bestScore = Math.Max(history.bestScore, score);
            history.lastSaved = run.savedAt;

            SafeWriteJson(GetFilePath(), JsonUtility.ToJson(history, true));
        }

        public static bool TryLoadHistory(out ScoreHistory history)
        {
            string path = GetFilePath();
            if (!File.Exists(path))
            {
                history = null;
                return false;
            }

            try
            {
                string json = File.ReadAllText(path);
                history = JsonUtility.FromJson<ScoreHistory>(json) ?? new ScoreHistory();
                return true;
            }
            catch (Exception)
            {
                history = null;
                return false;
            }
        }

        public static bool TryGetLastRun(out ScoreRun lastRun)
        {
            if (TryLoadHistory(out var history) && history.runs.Count > 0)
            {
                lastRun = history.runs[^1];
                return true;
            }
            lastRun = null;
            return false;
        }

        public static void DeleteHistory()
        {
            string path = GetFilePath();
            if (File.Exists(path))
                File.Delete(path);
        }

        private static ScoreHistory LoadOrCreateHistoryInternal()
        {
            if (TryLoadHistory(out var history) && history != null)
                return history;
            return new ScoreHistory { bestScore = int.MinValue, totalRuns = 0 };
        }

        private static string GetFilePath()
        {
            return Path.Combine(Application.persistentDataPath, "score_history.json");
        }

        private static void SafeWriteJson(string finalPath, string json)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(finalPath)!);

            string tempPath = finalPath + ".tmp";
            File.WriteAllText(tempPath, json);
            if (File.Exists(finalPath))
                File.Replace(tempPath, finalPath, null);
            else
                File.Move(tempPath, finalPath);
        }
    }
}
