using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlaceholder : EventTrigger
{

    public Tower tower;
    public bool isEmpty = true;

    public override void OnPointerClick(PointerEventData data)
    {
        Debug.Log("OnPointerClick called.");
            
    }

}
