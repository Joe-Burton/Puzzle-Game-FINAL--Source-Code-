using TMPro;
using UnityEngine;

public class LoadTextFileRes : MonoBehaviour
{
    public TMP_Text textTarget; // Output target
    private string FastestTime = "FastestTime"; // Don't include .txt in name

    void Start()
    {
        // Loads from Assets/Resources
        TextAsset myTextFile = (TextAsset)Resources.Load(FastestTime);
        string myText = myTextFile.text;
        textTarget.text = myText;
    }
}