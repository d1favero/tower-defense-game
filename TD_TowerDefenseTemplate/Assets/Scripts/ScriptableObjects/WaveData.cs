using UnityEngine;

[CreateAssetMenu(fileName ="New WaveData", menuName ="TD - TowerDefense / Data / WaveData")]
public class WaveData : ScriptableObject
{
    public GameObject enemyPrefab;
    public int count;
    [Range(0.1f, 1f)]
    public float rate;
}
