using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text sheepSavedText;
    public Text sheepDroppedText;
    public Text highScoreText; // Text component to display the high score
    public GameObject gameOverWindow;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void UpdateSheepSaved()
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped()
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void ShowGameOverWindow(int highScore)
    {
        // Set the high score text
        highScoreText.text = "High Score: " + highScore.ToString();

        gameOverWindow.SetActive(true);
    }
}
