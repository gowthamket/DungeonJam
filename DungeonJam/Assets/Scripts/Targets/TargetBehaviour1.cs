using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetBehaviour1 : MonoBehaviour
{
    
    public Transform[] pointList;
    public float moveSpeed = 5f;
    public float waitDuration = 1f;

    private int currentPointIndex = 0;
    private bool isMoving = false;

    private void Start()
    {
        
        // Set initial position to first point in list
        transform.position = pointList[currentPointIndex].position;
    }

    private void Update()
    {
        if (!isMoving)
        {
            // Start moving to the next point in the list
            currentPointIndex = (currentPointIndex + 1) % pointList.Length;
            Vector3 nextPoint = pointList[currentPointIndex].position;
            StartCoroutine(MoveToNextPoint(nextPoint));
        }
    }

    private IEnumerator MoveToNextPoint(Vector3 targetPoint)
    {
        isMoving = true;
        float distance = Vector3.Distance(transform.position, targetPoint);
        float duration = distance / moveSpeed;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPoint, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final position is exactly on the target point
        transform.position = targetPoint;

        // Wait for a short duration at the target point
        yield return new WaitForSeconds(waitDuration);

        isMoving = false;
    }
}

