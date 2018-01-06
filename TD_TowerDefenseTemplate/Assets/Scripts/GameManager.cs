using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    Spawner spawner;
    static int playerLife;
    static int playerMoney;
    static int playerScore;
    int playerWaves;

    [SerializeField]
    int playerStartLife = 10;
    [SerializeField]
    int playertStartMoney = 50;
    [SerializeField]
    int playerStartScore = 0;
    [SerializeField]
    int playerStartWaves = 0;

    [SerializeField]
    UserInterfaceManager uiManager;
    [SerializeField]
    public GameObject[] Waypoints;

    public static bool isGameOver;

    public static int PlayerLife
    {
        get { return playerLife; }
        set { playerLife = value; }
    }

    public static int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    public static int PlayerMoney
    {
        get { return playerMoney; }
        set { playerMoney = value; }
    }

    public int PlayerWaves
    {
        get { return playerWaves; }
        set { playerWaves = value; }
    }

    private void Start()
    {
        isGameOver = false;
        playerLife = playerStartLife;
        playerMoney = playertStartMoney;
        playerScore = playerStartScore;
        PlayerWaves = playerStartWaves;
    }

    void Update()
    {
        if (isGameOver)
            return;

        if (spawner.waveIndex == spawner.waves.Length)
        {
            WinLevel();
        }

        if (playerLife <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        isGameOver = true;
        uiManager.ActivateGameOverPanel(false);
    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt("playerLevelReached", PlayerPrefs.GetInt("playerLevelReached") + 1);
        isGameOver = true;
        print("Level WIN!!!");
        uiManager.ActivateGameOverPanel(true);
    }
}
