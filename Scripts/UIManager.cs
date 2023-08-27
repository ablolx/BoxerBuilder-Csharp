using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button startButton; // Reference to the start button

    private void Start()
    {
        // Attach the button's onClick event to the StartGame() function
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        // Load the game scene when the start button is clicked
        SceneManager.LoadScene("Main");
    }
}
