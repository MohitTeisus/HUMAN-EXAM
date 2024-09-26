using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEquipStrategy : IShootStrategy
{
    EquipInteractor interactor;
    Transform shootPoint;

    public NoEquipStrategy(EquipInteractor _interactor)
    {
        Debug.Log("switched to unequiped items");
        this.interactor = _interactor;
    }

    public void Shoot()
    {
        
    }
}
