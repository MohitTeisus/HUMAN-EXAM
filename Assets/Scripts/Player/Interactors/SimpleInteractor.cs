using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteractor : Interactor
{
    [Header("Interact")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private float interactionDistance;
    //[SerializeField] private GameObject interactTxt;

    //Raycast
    private RaycastHit raycastHit;
    private ISelectable selectable;

    public override void Interact()
    {
        //Cast a Ray
        //Draw the ray form a point
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out raycastHit, interactionDistance, interactionLayer))
        {
            selectable = raycastHit.transform.GetComponent<ISelectable>();

            if (selectable != null)
            {
                Observer.onInteractHover?.Invoke(true);
                selectable.OnHoverEnter();

                if (input.activatePressed)
                {
                    selectable.OnSelect();
                }
            }
        }

        if (raycastHit.transform == null && selectable != null)
        {
            Observer.onInteractHover?.Invoke(false);
            selectable.OnHoverExit();
            selectable = null;
        }
    }
}
