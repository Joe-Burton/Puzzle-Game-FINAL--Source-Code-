using UnityEngine;
using TMPro;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
    public TMP_Text highScoreText;
    private string highScoreFilePath;

    void Start()
    {
        // Define the file path for high scores
        highScoreFilePath = Path.Combine(Application.dataPath, "Resources", "HighScores.txt");

        // Load and display the high score
        LoadAndDisplayHighScore();
    }

    private void LoadAndDisplayHighScore()
    {
        // Check if the high score file exists
        if (File.Exists(highScoreFilePath))
        {
            try
            {
                // Read the high score from the file
                string highScoreString = File.ReadAllText(highScoreFilePath);

                // Parse the high score value
                if (float.TryParse(highScoreString, out float bestTime))
                {
                    // Display the high score
                    highScoreText.text = $"High Score: {bestTime:F2}s";
                }
                else
                {
                    Debug.LogError("Failed to parse high score from the file.");
                }
            }
            catch (IOException ex)
            {
                Debug.LogError($"Failed to read high score: {ex.Message}");
            }
        }
        else
        {
            Debug.LogWarning("High score file not found.");
        }
    }

    public void SaveScore(string playerName, float bestTime)
    {
        // Format the score data
        string scoreData = $"{playerName}: {bestTime:F2}s";

        try
        {
            // Append the score data to the high scores file
            File.AppendAllText(highScoreFilePath, scoreData + "\n");
            Debug.Log("Score saved successfully!");

            // Update the displayed high score
            highScoreText.text = $"High Score: {bestTime:F2}s";
        }
        catch (IOException ex)
        {
            Debug.LogError($"Failed to save score: {ex.Message}");
        }
    }
    

}
