using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterfaceManager : MonoBehaviour
{

    public static bool stopTimer = false;
    float timer;

    public RectTransform winPanel, losePanel, pausePanel;
    public Text waveNumberValue, waveQuantityValue, waveCountdownValue, timerValue, scoreValue, moneyValue, lifeValue;

    public Button retryButton, continueButton;
    public Button[] mainMenuButton;
    public string mainMenuSceneName;
    public string levelSelectionSceneName;
    Spawner spawner;
    

    void Start()
    {
        stopTimer = false;
        Time.timeScale = 1f;

        spawner = FindObjectOfType<Spawner>().GetComponent<Spawner>();

        retryButton.onClick.AddListener(RetryLevel);
        continueButton.onClick.AddListener(ContinueGame);

        for (int i = 0; i < mainMenuButton.Length; i++)
        {
            mainMenuButton[i].onClick.AddListener(ReturnToMainMenu);
        }
        
        winPanel.gameObject.SetActive(false);
        losePanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void ContinueGame()
    {
        // unpause
        Pause();
    }

    public void RetryLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene(levelSelectionSceneName);
    }

    public void Pause()
    {
        
        pausePanel.gameObject.SetActive(!pausePanel.gameObject.activeSelf);

        if (pausePanel.gameObject.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
        if (!stopTimer)
        {
            timer += Time.deltaTime;
            timerValue.text = string.Format("{0:00.00}", timer);
        }

        SetWaveInfo();
    }

    public void SetWaveInfo()
    {
        scoreValue.text = GameManager.PlayerScore.ToString();
        moneyValue.text = GameManager.PlayerMoney.ToString();
        lifeValue.text = GameManager.PlayerLife.ToString();
        waveNumberValue.text = (spawner.waveIndex + 1).ToString();
        waveQuantityValue.text = Spawner.enemiesInWave.ToString();
        waveCountdownValue.text = string.Format("{0:00.00}", spawner.countdown);
    }

    public void ActivateGameOverPanel(bool isWin)
    {
        if (isWin)
            winPanel.gameObject.SetActive(true);
        else
            losePanel.gameObject.SetActive(true);
    }

}
