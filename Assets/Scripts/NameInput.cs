using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class NameInput : MonoBehaviour
{
    public TMP_InputField NameEntry; // Reference to the Input Field UI element in the scene
    public string playerName; // Variable to store the player's name
    public UnityEvent onNameCaptured;
    public void CapturePlayerName()
    {
        playerName = NameEntry.text;
        Debug.Log("Player's name: " + playerName);
        onNameCaptured.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
