using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private bool isUp = false;
    [SerializeField] private float speed;

    Vector3 destination;
    bool isMoving = false;

    public void ToggleLift()
    {
        if (isMoving) 
            return;

        if (isUp)
        {
            destination = transform.localPosition - new Vector3(0, distance, 0);
            isUp = false;
        }
        else
        {
            destination = transform.localPosition + new Vector3(0, distance, 0);
            isUp = true;
        }

        isMoving = true;
    }

    private void FixedUpdate()
    {
        if(isMoving)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, destination, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.localPosition, destination) < 0.05f)
        {
            isMoving = false;
        }
    }
}
