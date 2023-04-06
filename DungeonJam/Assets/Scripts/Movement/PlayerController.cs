using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    
    private Quaternion rotation;
    //private bool isRotating = false;
    private float targetRotation = 0f;
    bool CanMove = true;
    public bool SmoothTransition = false;
    public float MoveTransitionSpeed = 5f;
    public float RotateTransitionSpeed = 100f;
    [HideInInspector]
    public bool isMoving = false;
    public bool isRotating = false;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        targetGridPos = Vector3Int.RoundToInt(transform.position);

        rotation = transform.rotation;
        
    }


    //testing movement code below
    public void RotateLeft()
    {
        isRotating = true;
        targetRotation -= 90f;
      
    }

    public void RotateRight()
    {
        isRotating = true;
        targetRotation += 90f;
    }

    public void MoveForward()
    {
        isMoving = true;
        targetGridPos += transform.forward * 2f;

    }

    public void Movebackward()
    {
        isMoving = true;
        targetGridPos -= transform.forward * 2f;

    }

   

   

    private void FixedUpdate()
    {
        MovePlayer();
        if(isRotating == true)
        {

            StartCoroutine(RotatePlayer());
        }
        

    }
    void MovePlayer()
    {
        if(CanMove)
        {
            prevTargetGridPos = targetGridPos;
            Vector3 currentPosition = targetGridPos;
           

            if(!SmoothTransition)
            {
                transform.position = currentPosition;

                
            }
            else
            {

                Vector3 PlayerPos = Vector3.MoveTowards(transform.position, currentPosition, Time.deltaTime * MoveTransitionSpeed);
                transform.position = PlayerPos;
                if(Vector3.Distance(PlayerPos, currentPosition) < 0.1f)
                {
                    isMoving = false;
                }
               
            }
         
        }
        else
        {
            targetGridPos = prevTargetGridPos;
        }
    }

    IEnumerator RotatePlayer()
    {
      
        if (targetRotation > 270f && targetRotation < 361f) targetRotation = 0f;
        if (targetRotation < 0f) targetRotation = 270f;

        if (!SmoothTransition)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, targetRotation, 0f));
        }
        else
        {
            while(transform.rotation.eulerAngles.y != targetRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0f, targetRotation, 0f)), Time.deltaTime * RotateTransitionSpeed);
                yield return null;
            }



            isRotating = false;




        }



    }
    // Update is called once per frame
    void Update()
    {

        CollisionDetection();
        
        
    }

    public void CollisionDetection()
    {
        //raycast in order to detect collisions infront of player, cant walk through walls
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
        if (Physics.Raycast(ray, out hit, 100))
        {
            CanMove = false;
        }
        else
        {
            CanMove = true;
        }
    }
}
