using System.IO;
using UnityEngine;

namespace JensenBeard.Scoreboard
{
    public class Highscores : MonoBehaviour
    {
        [SerializeField] private int maxEntryLimit = 5;
        [SerializeField] private Transform highscoresContainerTransform;
        [SerializeField] private GameObject highscoreEntryTemplate;

        //Test Data
        [SerializeField] HighscoreEntry testEntryData = new HighscoreEntry();

        private string SavePath => $"{Application.persistentDataPath}/highscores.json";

        private void Start()
        {
            HighscoreSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);
        }

        [ContextMenu("Test")]
        public void AddTestEntry() 
        {
            AddEntry(testEntryData);
        }


        public void AddEntry(HighscoreEntry highscoreEntry) 
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

            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        private void UpdateUI(HighscoreSaveData savedScores) 
        {
            foreach (Transform child in highscoresContainerTransform) 
            {
                Destroy(child.gameObject);
            }

            foreach (HighscoreEntry highscore in savedScores.highscoreList) 
            {
                Instantiate(highscoreEntryTemplate, highscoresContainerTransform).GetComponent<HighscoreUI>().Initalise(highscore);
            }
        }

        private HighscoreSaveData GetSavedScores() 
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

        private void SaveScores(HighscoreSaveData highscoreSaveData) 
        {
            using (StreamWriter stream = new StreamWriter(SavePath)) 
            {
                string json = JsonUtility.ToJson(highscoreSaveData, true);
                stream.Write(json);
            }
        }
    }

}


