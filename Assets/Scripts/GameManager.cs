using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text scoreText;
    [SerializeField]
    TMPro.TMP_Text gameOverScore;
    [SerializeField]
    TMPro.TMP_Text gameOverPlace;
    [SerializeField]
    GameObject gameOverPanel;
    int currentScore = 0;
    int columnNumber;
    bool gameEnded = false;
    private void Start()
    {
        columnNumber = GetComponent<EnemyMaster>().ColumnNumber;
    }

    public void AddPoint()
    {
        currentScore++;
        UpdateScoreTextBox();
    }
    public void SubstractPoints()
    {
        currentScore -= 2 * columnNumber;
        UpdateScoreTextBox();
    }
    void UpdateScoreTextBox()
    {
        scoreText.text = "Punkty: " + currentScore.ToString();
    }
    public void EndGame()
    {
        if (gameEnded) 
            return;
        gameEnded = true;
        GetComponent<EnemyMaster>().ClearEnemies();
        gameOverScore.text = currentScore.ToString();
        int place = HighScores.InsertNewScore(currentScore);
        if (place != 0)
            gameOverPlace.text = "Ten wynik jest na " + place.ToString() + " miejscu w tabeli wszechczasów!";
        else
            gameOverPlace.text = "";
        gameOverPanel.SetActive(true);
    }
    public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
