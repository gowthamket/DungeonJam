using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Target2":
                Destroy(this.gameObject);

                Destroy(collision.gameObject);
                gameManager.HitTarget();
                break;

            case "Target3":
                Destroy(this.gameObject);
                
                break;

            default:
                gameManager.LoseLife();
                Destroy(this.gameObject);
                break;


        };

       
       

        
        
    }
}
