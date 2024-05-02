using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool timerActive = true;
    public TMP_Text timerText;

    void Update()
    {
        if (timerActive && timerText != null)
        {
            elapsedTime += Time.deltaTime;

            // Convert elapsed time to minutes, seconds, and milliseconds
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000f);

            // Update timer text
            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

            // Check for space bar input to stop the timer and load the HighScoreScene
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StopTimerAndLoadHighScoreScene();
            }
        }
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    private void StopTimerAndLoadHighScoreScene()
    {
        if (timerActive && timerText != null)
        {
            timerActive = false;
            RecordHighScore(elapsedTime);
            SceneManager.LoadScene("HighScoreScene");
        }
    }

    private void RecordHighScore(float time)
    {
        string filePath = Application.dataPath + "/Resources/FastestTime.txt";
        if (File.Exists(filePath))
        {
            string highScoreString = File.ReadAllText(filePath);
            if (float.TryParse(highScoreString, out float previousHighScore))
            {
                if (time < previousHighScore)
                {
                    File.WriteAllText(filePath, time.ToString());
                }
            }
        }
    }
}