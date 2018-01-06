using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    Button[] levelButtons;

    private void Start()
    {
        int playerLevelReached = PlayerPrefs.GetInt("playerLevelReached", 1);

        print(playerLevelReached);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > playerLevelReached)
                levelButtons[i].interactable = false;
        }
    }

    public void SelectLevel(string levelName)
    {

        SceneManager.LoadScene(levelName);
    }
}
