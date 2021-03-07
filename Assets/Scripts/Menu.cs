using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text gamesPlayed;
    [SerializeField]
    TMPro.TMP_Text[] highScoresTextBoxes;
    private void Start()
    {
        HighScores.Init();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadStats()
    {
        gamesPlayed.text = PlayerPrefs.GetInt("GamesPlayed").ToString();
        int i = 0;
        int[] highScores = HighScores.GetHighScores();
        foreach (var item in highScores)
        {
            Debug.Log(item);
        }
        foreach (var hsTb in highScoresTextBoxes)
        {
            if(i < highScores.Length)
            {
                hsTb.gameObject.SetActive(true);
                hsTb.text = (i + 1) + ". " + highScores[i].ToString();
            }
            else
                hsTb.gameObject.SetActive(false);
            i++;
        }
    }
}
