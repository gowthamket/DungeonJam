using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUI : MonoBehaviour
{
    public GameObject UIRef;
    public GameObject TargetPrefab;
    public GameObject TargetSpawnPoint;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            UIRef.SetActive(true);
            Instantiate(TargetPrefab, TargetSpawnPoint.transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        

    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }
}
