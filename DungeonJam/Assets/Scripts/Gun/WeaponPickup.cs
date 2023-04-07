using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public float pickupDistance = 2f; // Distance the player needs to be to pick up the weapon
    public GameObject playerHand; // Where the weapon will be held by the player

    public Collider weaponCollider;
    [HideInInspector]
    public bool pickedUp = false;

    void Start()
    {
        weaponCollider = GetComponent<Collider>();
    }

    void OnMouseDown()
    {
        float distance = Vector3.Distance(transform.position, playerHand.transform.position);

        if (distance <= pickupDistance)
        {
            weaponCollider.enabled = false;
            transform.SetParent(playerHand.transform); // Move the weapon to the player's hand
            transform.localPosition = Vector3.zero; // Reset the position to the hand's origin
            StartCoroutine(WaitToShoot());
        }
    }

    IEnumerator WaitToShoot()
    {
        yield return new WaitForSeconds(.5f);
        pickedUp = true;  //when the weapon is picked up, you are able to shoot
    }
}

