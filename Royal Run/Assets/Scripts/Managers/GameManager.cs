using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerControler playerControler;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    float timeLeft;
    bool gameOver = false;

    //public bool GameOver{ get { return gameOver; } } same with public bool GameOver => gameOver;
    public bool GameOver => gameOver;

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        DecreaseTime();
    }

    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }
   
    void PlayerGameOver()
    {
        gameOver = true;
        playerControler.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
    void DecreaseTime()
    {
        if (gameOver) return;
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }
    }
}
