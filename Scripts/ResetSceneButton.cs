using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetSceneButton : MonoBehaviour
{
    private void Start()
    {
        // Attach the button's onClick event to the ResetScene() function
        Button resetButton = GetComponent<Button>();
        resetButton.onClick.AddListener(ResetScene);
    }

    private void ResetScene()
    {
        // Get the current scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}
