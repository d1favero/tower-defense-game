using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour
{
    public static int enemiesInWave = 0;
    public float intervalBetweenWaves = 5f;

    public WaveData[] waves;
    public Transform[] spawnPoints;

    public float countdown = 2f;
    [HideInInspector]
    public int waveIndex = 0;

    UserInterfaceManager uiManager;
    GameManager gameManager;
    public bool isSpawning = false;

    private void Start()
    {
        uiManager = FindObjectOfType<UserInterfaceManager>().GetComponent<UserInterfaceManager>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

    }

    private void Update()
    {

        if (enemiesInWave > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            this.enabled = false;
            isSpawning = false;
        }

        if (countdown <= 0f)
        {
            UserInterfaceManager.stopTimer = false;
            StartCoroutine(SpawnWave());
            countdown = intervalBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

    }

    IEnumerator SpawnWave()
    {

        gameManager.PlayerWaves++;

        WaveData wave = waves[waveIndex];

        enemiesInWave = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            isSpawning = true;
            SpawnEnemy(wave.enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)]);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
        UserInterfaceManager.stopTimer = true;
        isSpawning = false;

    }

    private void SpawnEnemy(GameObject enemyPrefab, Transform spawnPoint)
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
