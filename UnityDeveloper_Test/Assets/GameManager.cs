using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public float gameTime = 120f; // 2 minutes in seconds
    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        gameTime -= Time.deltaTime;

        // Check if the timer has reached zero
        if (gameTime <= 0f)
        {
            gameTime = 0f;
            GameOver();
        }

        // Format the time as minutes:seconds
        float minutes = Mathf.FloorToInt(gameTime / 60);
        float seconds = Mathf.FloorToInt(gameTime % 60);

        // Update the UI text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over - Time's up!");
        // Add any additional game over logic here, such as showing a game over screen.
    }

    // Call this method when the player collects all cubes
    public void PlayerWins()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Congratulations! You collected all cubes!");
            // Add any additional win logic here.
        }
    }
}
