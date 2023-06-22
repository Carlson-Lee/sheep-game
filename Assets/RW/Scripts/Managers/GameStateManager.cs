using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [HideInInspector]
    public int sheepSaved;

    [HideInInspector]
    public int sheepDropped;

    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner;

    private int highScore; // Variable to store the high score

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        LoadHighScore(); // Load the high score when the game starts
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }

    private void GameOver()
    {
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
        
        // Check if the current score is higher than the previous high score
        if (sheepSaved > highScore)
        {
            highScore = sheepSaved; // Update the high score
            SaveHighScore(); // Save the new high score
        }
        
        // Display the high score on the game over screen
        UIManager.Instance.ShowGameOverWindow(highScore);
    }

    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();

        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            GameOver();
        }
    }

    private void SaveHighScore()
    {
        // Save the high score using PlayerPrefs or other storage mechanism
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    private void LoadHighScore()
    {
        // Load the high score from PlayerPrefs or other storage mechanism
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
