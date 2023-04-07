using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string GunName;
    public int Damage;
    public float fireRate;
    public float bulletSpeed;
}
