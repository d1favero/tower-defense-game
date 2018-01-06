using UnityEngine;

[CreateAssetMenu(fileName = "New TowerData", menuName = "TD - TowerDefense / Data / TowerData")]
public class TowerData : ScriptableObject
{
    [Header("Tower Parameters")]
    [SerializeField]
    public string towerName;

    [SerializeField] public int cost;
    [SerializeField] public int sellCost;
    [SerializeField] public float range;
    [Range(0.1f, 2f)]
    [SerializeField]
    public float fireRate;
    [SerializeField] public float turnSpeed = 10f;
    [TagSelector]
    [SerializeField]
    public string enemyTag;

    [Space(10)]
    [Header("Ammunition")]
    [SerializeField]
    public GameObject ammoPrefab;

    [SerializeField] public bool canUpgrade;
    [Header("Upgrade Data")]
    [SerializeField]
    public int upgradeCost;
    [SerializeField]
    public TowerData towerDataUpgrade;
    [SerializeField] public GameObject towerPrefabUpgrade;
}
