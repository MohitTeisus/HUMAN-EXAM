using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipInteractor : Interactor
{
    [Header("Equipment")]
    public GameObject gun;
    public GameObject commandWand;

    private List<GameObject> acquiredItems;

    [Header("Shoot")]
    public ObjectPool bulletPool;

    [SerializeField] private float shootForce;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private PlayerMoveBehaviour moveBehaviour;

    private float finalShootVelocity;
    private IShootStrategy currentShootStrategy;

    [Header("Command")]
    public RobotCommand robotCommand;

    public override void Interact()
    {
        if (currentShootStrategy == null)
        {
            UnequipAllItems();
            currentShootStrategy = new NoEquipStrategy(this);
        }

        if (input.weapon1pressed && gun != null)
        {
            UnequipAllItems();
            currentShootStrategy = new BulletShootStrategy(this);
        }

        if (input.weapon2pressed)
        {
            UnequipAllItems();
            currentShootStrategy = new CommandStrategy(this, robotCommand);
        }

        //Shoot strategy
        if (input.primaryShootPressed)
        {
            currentShootStrategy.Shoot();
        }
    }

    public void AssignGun(GameObject gun)
    {
        this.gun = gun;
        acquiredItems.Add(gun);
    }

    public void AssignWand(GameObject wand)
    {
        this.commandWand = wand;
        acquiredItems.Add(wand);
    }

    public Transform GetShootPoint()
    {
        return shootPoint;
    }

    public float GetShootVelocity()
    {
        finalShootVelocity = moveBehaviour.GetForwardSpeed() + shootForce;
        return finalShootVelocity;
    }

    private void UnequipAllItems()
    {
        if(acquiredItems.Count > 0)
        {
            foreach(var item in acquiredItems)
            {
                item.SetActive(false);
            }
        }
    }
}
