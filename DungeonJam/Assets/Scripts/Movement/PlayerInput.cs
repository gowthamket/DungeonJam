using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    

    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode turnleft = KeyCode.Q;
    public KeyCode turnright = KeyCode.E;

    PlayerController controller;

    

    private void Awake()
    {
        controller = GetComponent<PlayerController>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(forward) && controller.isMoving == false && controller.isRotating == false)
        {
            controller.MoveForward();
        }
        if (Input.GetKeyDown(turnright) && controller.isRotating == false && controller.isMoving == false)
        {
            controller.RotateRight();
        }

        if(Input.GetKeyDown(turnleft) && controller.isRotating == false && controller.isMoving == false)
        {
            controller.RotateLeft();
        }
            
        if (Input.GetKeyDown(backward) && controller.isMoving == false && controller.isRotating == false)
        {
            controller.Movebackward();
        }
        
    }


}
