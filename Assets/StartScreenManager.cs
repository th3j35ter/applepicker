using UnityEngine;
using UnityEngine.UI; // Import the UI namespace
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public Button playButton; // Public variable for the Play Button

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(TaskOnClick); // Add the button listener
        }
        else
        {
            Debug.LogError("Play Button is not assigned in the Inspector!");
        }
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("SampleScene"); // Load the game scene
    }
}
