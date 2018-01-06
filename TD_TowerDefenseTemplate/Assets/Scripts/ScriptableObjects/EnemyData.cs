using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "TD - TowerDefense / Data / EnemyData")]
public class EnemyData : ScriptableObject
{

    public float speed;
    public float health;
    public float startHealth;
    public int reward;
    public int money;
    public Color color;
    public GameObject deathEffect;

}
