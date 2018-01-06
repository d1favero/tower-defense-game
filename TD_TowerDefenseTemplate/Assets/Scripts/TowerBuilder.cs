using System;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{

    public static TowerBuilder instance;

    public GameObject towerPrefab01, towerPrefab02, towerPrefab03;
    public GameObject buildFX;
    public TowerUI towerUI;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Just need one tower builder in scene!");
            return;
        }

        instance = this;
    }


    private GameObject tower;
    private Node selectedTowerNode;

    public bool CanBuild
    {
        get { return tower != null; }
    }

    public bool PlayerHasMoney
    {
        get { return GameManager.PlayerMoney >= tower.GetComponent<Tower>().towerData.cost; }
    }

    public bool PlayerHasUpgradeMoney
    {
        get { return GameManager.PlayerMoney >= tower.GetComponent<Tower>().towerData.upgradeCost; }
    }

    public void BuildTower(Node node)
    {
        if (!PlayerHasMoney)
        {
            print("No Money, poor bastard");
            return;
        }

        GameManager.PlayerMoney -= tower.GetComponent<Tower>().towerData.cost;
        GameObject buildedTower = Instantiate(tower, node.GetBuildPosition(), Quaternion.identity);
        node.tower = buildedTower;
        selectedTowerNode = node;
        BuildEffect();
        DeselectTowerNode();

    }

    public void UpgradeTower()
    {

        if (!PlayerHasUpgradeMoney || !TowerCanUpgrade())
        {
            print("No Money, poor bastard");
            DeselectTowerNode();
            return;
        }

        GameManager.PlayerMoney -= tower.GetComponent<Tower>().towerData.upgradeCost;
        GameObject upgradedTower = Instantiate(selectedTowerNode.tower.GetComponent<Tower>().towerData.towerPrefabUpgrade, selectedTowerNode.GetBuildPosition(), Quaternion.identity);
        Destroy(selectedTowerNode.tower);
        selectedTowerNode.tower = upgradedTower;

        BuildEffect();
        DeselectTowerNode();

    }

    private bool TowerCanUpgrade()
    {
        return tower.GetComponent<Tower>().towerData.canUpgrade;
    }

    public void SellTower()
    {
        GameManager.PlayerMoney += selectedTowerNode.tower.GetComponent<Tower>().towerData.sellCost;
        Destroy(selectedTowerNode.tower);
        selectedTowerNode.tower = null;
        BuildEffect();
        DeselectTowerNode();
    }

    public void SelectTowerNode(Node nodeTower)
    {
        if (selectedTowerNode == nodeTower)
        {
            DeselectTowerNode();
            return;
        }

        selectedTowerNode = nodeTower;
        tower = nodeTower.tower;
        towerUI.SetNodeTarget(nodeTower);
        towerUI.SetButtonsText(tower.GetComponent<Tower>().towerData.upgradeCost.ToString(),
            tower.GetComponent<Tower>().towerData.sellCost.ToString());

    }

    private void DeselectTowerNode()
    {
        selectedTowerNode = null;
        towerUI.Hide();
    }

    public void SetTowerTobuild(GameObject towerPref)
    {
        tower = towerPref;
        DeselectTowerNode();
    }

    void BuildEffect()
    {
        GameObject effect = Instantiate(buildFX, selectedTowerNode.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);
    }
}
