using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target3Collision : MonoBehaviour
{
    public TargetBehaviour3 scriptREF;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            scriptREF.AddHitCount();
        }
    }
}
