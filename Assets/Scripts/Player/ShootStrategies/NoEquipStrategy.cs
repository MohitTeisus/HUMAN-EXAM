using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEquipStrategy : IEquipStrategy
{
    EquipInteractor interactor;

    public NoEquipStrategy(EquipInteractor _interactor)
    {
        Debug.Log("switched to unequiped items");
        this.interactor = _interactor;
        interactor.hand.SetActive(true);
    }

    public void UseEquipment()
    {
        
    }
}
