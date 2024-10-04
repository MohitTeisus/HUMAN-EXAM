using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupInteractor : Interactor
{
    [Header("Pick and Drop")]
    [SerializeField] private Transform attachPoint;
    [SerializeField] private float pickupDistance;
    [SerializeField] private LayerMask pickupLayer;
    [SerializeField] private Camera cam;

    private RaycastHit raycastHit;
    private bool isPicked = false;
    private IPickable pickable;

    public override void Interact() //Allows the player to pickup objects
    {
        //Cast a Ray
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out raycastHit, pickupDistance, pickupLayer))
        {
            if (input.activatePressed && !isPicked)
            {
                pickable = raycastHit.transform.GetComponent<IPickable>();

                if (pickable == null)
                    return;

                pickable.OnPicked(attachPoint);
                isPicked = true;

                Observer.onPickupHover?.Invoke(false);
                return;
            }

            if(!isPicked) Observer.onPickupHover?.Invoke(true); //Sends signal to enable pickup ui
        }

        if (raycastHit.transform == null)
        {
            Observer.onPickupHover?.Invoke(false);
        }

        if (input.activatePressed && isPicked && pickable != null)
        {
            pickable.OnDropped();
            isPicked = false;
        }
    }

   
}
