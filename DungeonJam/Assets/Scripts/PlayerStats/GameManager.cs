using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int MaxBullets;
    public int currentBullets;
    public int NumOfTargetsHit = 0;
    public TextMeshProUGUI targetCount;

    

    public Image[] bulletImages;


    // Start is called before the first frame update
    void Start()
    {
        targetCount.text = "Targets Hit: " + NumOfTargetsHit + "/10";
        currentBullets = MaxBullets;
        for (int i = 0; i < MaxBullets; i++)
        {
            bulletImages[i].enabled = true;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLife()
    {
        currentBullets--;
        bulletImages[currentBullets].enabled = false;

    }

    public void GainLife()
    {
        if(currentBullets > 0 && currentBullets < MaxBullets)
        {
            currentBullets++;
            bulletImages[currentBullets].enabled = true;
        }
        
    }

    public void HitTarget()
    {
        NumOfTargetsHit++;
        targetCount.text = "Targets Hit: " + NumOfTargetsHit + "/10";
    }

    public bool CanShoot()
    {
        if(currentBullets > 0)
        {
            return true;
        }
        else
        {
            Debug.Log("Game Over");
            return false;
        }
    }
}
