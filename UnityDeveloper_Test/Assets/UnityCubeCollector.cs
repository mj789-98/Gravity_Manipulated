using UnityEngine;
using UnityEngine.UI;

public class UnityCubeCollector : MonoBehaviour
{
    public int totalCubes = 10; // Set the total number of cubes in the Inspector
    private int collectedCubes = 0;

    public Text timerText;
    private float timer = 120f; // 2 minutes in seconds

    void Start()
    {
        // Optionally, you can start the timer when the script is initialized
        //InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    void Update()
    {
        UpdateTimer();

        // Check if the time is up
        if (timer <= 0f)
        {
            GameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cube"))
        {
            // Assuming cubes have a "Cube" tag, you can change it based on your setup
            CollectCube();
            Destroy(other.gameObject); // Destroy the collected cube
        }
    }

    void CollectCube()
    {
        collectedCubes++;

        // Check if all cubes are collected
        if (collectedCubes >= totalCubes)
        {
            GameOver(); // You can also call a method to handle the player winning
        }
    }

    void UpdateTimer()
    {
        // Update the timer and display it if you have a Text component assigned
        timer -= Time.deltaTime;
        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(timer).ToString();
        }
    }

    void GameOver()
    {
        // Handle game over logic here
        Debug.Log("Game Over!");
    }
}
