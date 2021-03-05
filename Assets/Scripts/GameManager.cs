using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text scoreText;
    int currentScore = 0;
    int columnNumber;

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
        scoreText.text = "Points: " + currentScore.ToString();
    }
}
