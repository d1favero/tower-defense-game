using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor, noMoneyColor;
    [Tooltip("Change the position of the tower that will be build in this node.")]
    [SerializeField]
    private Vector3 offset;
    private Renderer nodeRenderer;
    private Color startColor;

    public GameObject tower;


    private void Start()
    {
        nodeRenderer = GetComponent<Renderer>();
        startColor = nodeRenderer.material.color;
    }

    private void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (tower != null)
        {
            TowerBuilder.instance.SelectTowerNode(this);
            return;
        }

        if (!TowerBuilder.instance.CanBuild)
            return;

        TowerBuilder.instance.BuildTower(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!TowerBuilder.instance.CanBuild)
            return;

        if (TowerBuilder.instance.PlayerHasMoney)
            nodeRenderer.material.color = hoverColor;
        else
            nodeRenderer.material.color = noMoneyColor;
    }

    private void OnMouseExit()
    {
        nodeRenderer.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;
    }
}
