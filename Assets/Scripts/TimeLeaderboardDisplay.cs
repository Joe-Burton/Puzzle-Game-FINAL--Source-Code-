using UnityEngine;
using TMPro;
using System.IO;

public class TimeLeaderboardDisplay : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText;

    void Start()
    {
        string leaderboard = "";

        // Load the leaderboard times from PlayerPrefs
        for (int i = 0; i < 5; i++)
        {
            float time = PlayerPrefs.GetFloat("LeaderboardTime" + i, float.MaxValue);
            string minutes = ((int)time / 60).ToString();
            string seconds = (time % 60).ToString("f2");
            //string milliseconds =((time * 1000f) % 1000f).ToString("f3");

            leaderboard += (i + 1) + minutes + ":" + seconds + "\n";
        }

        leaderboardText.text = leaderboard;
        
#if UNITY_EDITOR
        // File saving to your machine isn't really possible on a WebGL build.
        // You can only access your resource folder like this within the editor.
        // This will be used to record the fastest times.

        string fileName = "FastestTime";
        string path = "Assets/Resources/" + fileName + ".txt";

        // If the file exists, use it. Else, create one.
        if (File.Exists(path))
        {
            // Write leaderboard to file
            File.WriteAllText(path, leaderboard);
            Debug.Log(fileName + ".txt saved to: " + path);
        }
        else
        {
            Debug.Log(fileName + ".txt does not exist, creating file.");
            string dataToBeWritten = leaderboard;

            // Write leaderboard to file
            StreamWriter writer = new StreamWriter(path, true); // Append is true
            writer.WriteLine(dataToBeWritten);
            writer.Close();

            Debug.Log("Done writing " + fileName + ".txt");
        }
        // Re-import the file to update the reference in the editor
        UnityEditor.AssetDatabase.ImportAsset(path);
#endif
    }
}