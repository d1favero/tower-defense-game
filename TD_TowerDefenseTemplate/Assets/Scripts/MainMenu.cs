using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Canvas uiBase;
    public RectTransform uiPanelMenu;
    public Button startGameButton, quitButton;

    public string[] levelNames;


    void Start()
    {
        startGameButton.onClick.AddListener(StarGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void StarGame()
    {
        SceneManager.LoadSceneAsync(levelNames[0]);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
