using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EquipInteractor : Interactor
{
    [Header("Equipment")]
    public GameObject hand;
    public GameObject gun;
    public GameObject commandWand;

    [SerializeField] private List<GameObject> acquiredItems = new List<GameObject>();

    [Header("Shoot")]
    public ObjectPool bulletPool;

    [SerializeField] private float shootForce;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private PlayerMoveBehaviour moveBehaviour;

    private float finalShootVelocity;
    private IEquipStrategy currentEquipStrategy;

    [Header("Command")]
    public RobotCommand robotCommand;
    public ObjectPool commandPool;

    public override void Interact()
    {
        ChangeStrategy();

        //Shoot strategy
        if (input.primaryShootPressed)
        {
            currentEquipStrategy.UseEquipment();
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

    private void ChangeStrategy()
    {
        if (currentEquipStrategy == null)
        {
            UnequipAllItems();
            acquiredItems.Add(hand);
            currentEquipStrategy = new NoEquipStrategy(this);
        }

        if (input.weapon1pressed && gun != null)
        {
            UnequipAllItems();
            currentEquipStrategy = new BulletShootStrategy(this);
        }

        if (input.weapon2pressed && commandWand != null)
        {
            UnequipAllItems();
            currentEquipStrategy = new CommandStrategy(this, robotCommand);
        }

        if (input.weapon3pressed && hand != null)
        {
            UnequipAllItems();
            currentEquipStrategy = new NoEquipStrategy(this);
        }
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
