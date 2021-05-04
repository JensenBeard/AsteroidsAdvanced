using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class HighScoreWriter
{
    private static string SavePath => $"{Application.persistentDataPath}/highscores.json";
    private static int maxEntryLimit = 5;

    //Retrieves JSON from file
    public static HighscoreSaveData GetSavedScores()
    {
        if (!File.Exists(SavePath))
        {
            File.Create(SavePath).Dispose();
            return new HighscoreSaveData();
        }

        using (StreamReader stream = new StreamReader(SavePath))
        {
            string json = stream.ReadToEnd();

            return JsonUtility.FromJson<HighscoreSaveData>(json);
        }
    }

    //Saves JSON to file
    private static void SaveScores(HighscoreSaveData highscoreSaveData)
    {
        using (StreamWriter stream = new StreamWriter(SavePath))
        {
            string json = JsonUtility.ToJson(highscoreSaveData, true);
            stream.Write(json);
        }
    }

    //Adds a highscoreEntry to the existing list
    public static void AddEntry(HighscoreEntry highscoreEntry)
    {
        HighscoreSaveData savedScores = GetSavedScores();

        bool scoreAdded = false;

        for (int i = 0; i < savedScores.highscoreList.Count; i++)
        {
            if (highscoreEntry.entryScore > savedScores.highscoreList[i].entryScore)
            {
                savedScores.highscoreList.Insert(i, highscoreEntry);
                scoreAdded = true;
                break;
            }
        }

        if (!scoreAdded && savedScores.highscoreList.Count < maxEntryLimit)
        {
            savedScores.highscoreList.Add(highscoreEntry);
        }

        if (savedScores.highscoreList.Count > maxEntryLimit)
        {
            savedScores.highscoreList.RemoveRange(maxEntryLimit, savedScores.highscoreList.Count - maxEntryLimit);
        }
        SaveScores(savedScores);
    }
}
