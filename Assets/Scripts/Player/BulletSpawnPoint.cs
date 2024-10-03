using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnPoint : MonoBehaviour
{
    //Points the bulletspawnpoint so that it always faces directly where the player is aiming
    
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] Camera cam;

    Ray ray;
    RaycastHit hit;

    private void Update()
    {
        ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, 75f))
        {
            bulletSpawnPoint.LookAt(hit.point);
        }
    }
}
