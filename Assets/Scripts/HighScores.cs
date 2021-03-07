using System.Collections.Generic;
using System.Text;
using UnityEngine;
public static class HighScores
{
    static List<int> highscores = new List<int>();

    public static void Init()
    {
        highscores.Clear();
        if (PlayerPrefs.HasKey("HighScores"))
        {
            string hs = PlayerPrefs.GetString("HighScores");
            string[] highscoresArray = hs.Split('|');
            Debug.Log(hs);
            foreach (var item in highscoresArray)
            {
                Debug.Log(item);
                highscores.Add(int.Parse(item));
            }
        }
        if (!PlayerPrefs.HasKey("GamesPlayed"))
            PlayerPrefs.SetInt("GamesPlayed", 0);
    }

    public static int InsertNewScore(int score)
    {
        PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);

        if (highscores.Count == 10 && highscores[9] > score)
            return 0;

        for (int i = 0; i < highscores.Count; i++)
        {
            if (score >= highscores[i])
            {
                highscores.Insert(i, score);
                SaveData();
                return i + 1;
            }
        }
        highscores.Add(score);
        SaveData();
        return highscores.Count;
    }
    static void SaveData()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(highscores[0]);
        for (int i = 1; i < highscores.Count; i++)
        {
            sb.Append("|" + highscores[i]);
        }
        Debug.Log(sb.ToString());
        PlayerPrefs.SetString("HighScores", sb.ToString());
    }

    public static int[] GetHighScores()
    {
        return highscores.ToArray();
    }
}
