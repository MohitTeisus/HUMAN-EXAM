using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class MoveableScreen : MonoBehaviour
{
    private Vector3 startPoint, endPoint;
    
    [SerializeField] private float speed;
    [SerializeField] private float horizontalDistance;
    [SerializeField] private float verticalDistance;
    private float timer;
    [SerializeField] private bool isOpen;

    private void Start()
    {
       startPoint = transform.position;
       endPoint = transform.position + new Vector3(horizontalDistance, verticalDistance, 0);

       StartCoroutine(MoveScreen(isOpen));
    }

    IEnumerator MoveScreen(bool open)
    {
        timer = 0;
        Vector3 startpos = transform.position;
        while (timer <= 1)
        {
            timer += Time.deltaTime;
            if (open)
            {
                transform.position = Vector3.Lerp(startpos, endPoint, speed * timer);
                yield return null;
            }
            else
            {
                transform.position = Vector3.Lerp(startpos, startPoint, speed * timer);
                yield return null;
            }
        }
        timer = 1;
    }

    public void StartMoveScreen()
    {
        isOpen = !isOpen;
        StopAllCoroutines();
        StartCoroutine(MoveScreen(isOpen));
    }

    public void StartMoveScreen(bool open)
    {
        isOpen = open;
        StopAllCoroutines();
        StartCoroutine(MoveScreen(isOpen));  
    }
}
