using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{

    public GameObject gameObjectUI;
    [SerializeField]
    Button upgradeButton;
    [SerializeField]
    private Text upgradeCostValue, sellCostValue;

    [Space(10)]
    [SerializeField]
    private Node node;

    private void Start()
    {
        Hide();
    }

    public void SetNodeTarget(Node nodeTarget)
    {
        if (!nodeTarget.tower.GetComponent<Tower>().towerData.canUpgrade)
        {
            print("This tower has the max upgrade.");
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeButton.interactable = true;
        }

        node = nodeTarget;
        transform.position = node.GetBuildPosition();
        gameObjectUI.SetActive(true);
    }

    public void Hide()
    {
        gameObjectUI.SetActive(false);
    }

    public void SetButtonsText(string upgradeValue, string sellValue)
    {
        upgradeCostValue.text = upgradeValue;
        sellCostValue.text = sellValue;
    }
}
