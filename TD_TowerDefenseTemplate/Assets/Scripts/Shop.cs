using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    TowerBuilder towerBuilder;

    private void Start()
    {
        towerBuilder = TowerBuilder.instance;
    }

    public void PurchaseTurret01()
    {
        towerBuilder.SetTowerTobuild(towerBuilder.towerPrefab01);
    }

    public void PurchaseTurret02()
    {
        towerBuilder.SetTowerTobuild(towerBuilder.towerPrefab02);
    }

    public void PurchaseTurret03()
    {
        towerBuilder.SetTowerTobuild(towerBuilder.towerPrefab03);
    }
}
