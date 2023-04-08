using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetBehaviour4 : MonoBehaviour
{
    public GameObject[] target;
    public Material[] materials;
    private GameObject curTarget1;
    private GameObject curTarget2;  
    private MeshRenderer RandomTarget1;
    private MeshRenderer RandomTarget2;
    private SphereCollider SphereColliderREF1;
    private SphereCollider SphereColliderREF2;
    private GameObject prevTarget;
    private int index;
    public int hitTargets;
    public int RequiredTargetsHit;
    private GameManager gameManager;
    public GameObject counter;
    private TextMeshPro CountText;
    private TextMeshPro whatToHitText;

    // Start is called before the first frame update
    void Start()
    {
        CountText = counter.GetComponent<TextMeshPro>();
        whatToHitText = counter.GetComponent<TextMeshPro>();
        gameManager = FindObjectOfType<GameManager>();
        CountText.text = "Targets Hit: " + hitTargets + "/" + RequiredTargetsHit;
        StartCoroutine(TargetSwitch());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TargetSwitch()
    {
        while (hitTargets < RequiredTargetsHit)
        {
            TargetSwitchLogic();
            yield return new WaitForSeconds(3f);
            whatToHitText.text = "";
            SphereColliderREF2.enabled = false;
            RandomTarget1.material = materials[0];
            RandomTarget2.material = materials[0];

        }


    }
    
    public void TargetSwitchLogic()
    {
        //index = Random.Range(0, target.Length);
        curTarget1 = target[0];
        curTarget2 = target[1];

        RandomTarget1 = curTarget1.GetComponent<MeshRenderer>();
        RandomTarget2 = curTarget2.GetComponent<MeshRenderer>();
        SphereColliderREF1 = RandomTarget1.GetComponent<SphereCollider>();
        SphereColliderREF2 = RandomTarget2.GetComponent<SphereCollider>();  
        SphereColliderREF1.enabled = true;
        SphereColliderREF2.enabled = false;
        RandomTarget1.material = materials[Random.Range(0, materials.Length)];
        RandomTarget2.material = materials[Random.Range(0, materials.Length)];
        whatToHitText.text = "Hit " + RandomTarget1.material.name;
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
