using UnityEngine;

[CreateAssetMenu(fileName = "New AmmoData", menuName = "TD - TowerDefense / Data / AmmoData")]
public class AmmoData : ScriptableObject
{
    public float damage;
    public float speed;
    public float damageRadius = 0;
    public Color color;
    public GameObject hitParticleEffect;
}
