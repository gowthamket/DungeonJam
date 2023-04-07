using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetBehaviour3 : MonoBehaviour
{
    public GameObject[] target;
    public Material[] materials;
    private GameObject curTarget;
    private MeshRenderer RandomTarget;
    private SphereCollider SphereColliderREF;
    private GameObject prevTarget;
    private int index;
    public int hitTargets; 
    public int RequiredTargetsHit;
    private GameManager gameManager;
    public GameObject counter;
    private TextMeshPro CountText;

    // Start is called before the first frame update
    void Start()
    {
        CountText = counter.GetComponent<TextMeshPro>();
        gameManager = FindObjectOfType<GameManager>();
        CountText.text = "Targets Hit: " + hitTargets + "/" + RequiredTargetsHit;
        StartCoroutine(TargetSwitch());
    }

    
    IEnumerator TargetSwitch()
    {
        while(hitTargets < RequiredTargetsHit)
        {
            TargetSwitchLogic();
            yield return new WaitForSeconds(3f);
            SphereColliderREF.enabled = false;
            RandomTarget.material = materials[0];

        }
       
        
    }
    private void Update()
    {
        
    }
    public void TargetSwitchLogic()
    {
        index = Random.Range(0, target.Length);
        curTarget = target[index];

        RandomTarget = curTarget.GetComponent<MeshRenderer>();
        SphereColliderREF = RandomTarget.GetComponent<SphereCollider>();
        SphereColliderREF.enabled = true;
        RandomTarget.material = materials[1];
    }

    public void AddHitCount()
    {
        hitTargets++;
        CountText.text = "Targets Hit: " + hitTargets + "/3";
        if (hitTargets == RequiredTargetsHit)
        {
            gameManager.HitTarget();
            Destroy(gameObject);
        }
    }

  

   


}
