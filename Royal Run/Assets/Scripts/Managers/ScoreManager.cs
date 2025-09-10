using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreboardText;
    int score = 0;
    public void IncreaseScore(int amount)
    {
        //if (gameManager.ReturnGameOver()) return;
        if (gameManager.GameOver) return;

        score += amount;
        scoreboardText.text = score.ToString();
    }
    
}
