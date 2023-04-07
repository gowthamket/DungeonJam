using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TragteBehaviour2 : MonoBehaviour
{
    private bool isRotating = false;
    public Vector3 axis = Vector3.forward; // Axis of rotation
    public float rotationTime = 1.0f; // Time to rotate 90 degrees
    public float waitTime = 1.0f; // Time to wait between rotations
    public SphereCollider targetCollider;
    private MeshRenderer targetMeshRenderer;
    public Material[] targetColour;


    // Start is called before the first frame update
    void Start()
    {
       
        
        targetMeshRenderer = GetComponent<MeshRenderer>();
        targetMeshRenderer.material = targetColour[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateObject());
        }

    }

    private IEnumerator RotateObject()
    {
        isRotating = true;

        targetCollider.enabled = false;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * Quaternion.Euler(axis * 90);

        float t = 0.0f;
        while (t < 1.0f)
        {
           
            targetMeshRenderer.material = targetColour[1];
            t += Time.deltaTime / rotationTime;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }
        
        yield return new WaitForSeconds(waitTime);

        t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime / rotationTime;
            transform.rotation = Quaternion.Slerp(endRotation, startRotation, t);
            yield return null;
        }
        targetCollider.enabled = true;
       
        targetMeshRenderer.material = targetColour[0];
        yield return new WaitForSeconds (waitTime);
        isRotating = false;
    }

}
