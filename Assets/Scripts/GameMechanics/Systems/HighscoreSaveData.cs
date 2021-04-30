using System.Collections.Generic;
using System;


namespace JensenBeard.Scoreboard {
    [Serializable]
    public class HighscoreSaveData
    {
        public List<HighscoreEntry> highscoreList = new List<HighscoreEntry>();
    }

}
