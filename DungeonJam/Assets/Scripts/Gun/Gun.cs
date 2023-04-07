using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public WeaponData weaponData;
    public GameObject gunEnd;

    private Camera cam;
    private Vector3 aim;
  


    //private WeaponPickup EquippedWeapon;
    private GameManager gameManager;
    //Animator animator;
   
   
    private float nextFireTime = 0f;

    private void Start()
    {
        //EquippedWeapon = GetComponent<WeaponPickup>();
        //animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();

        cam = Camera.main;
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
      

        if(Input.GetButton("Fire1") && Time.time >= nextFireTime && gameManager != null && gameManager.CanShoot())
        {
            FireWeapon();
        }


    }

  

    void FireWeapon()
    {
        if(gameManager.currentBullets > 0)
        {
            nextFireTime = Time.time + weaponData.fireRate;
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject newGameObject = (GameObject)Instantiate(bulletPrefab, mouseRay.origin, transform.rotation);
            Rigidbody rb = newGameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {

                rb.velocity = mouseRay.direction * weaponData.bulletSpeed;
            }
            //StartCoroutine(WaitToDestroy(newGameObject));
            
        }
       
    }

    IEnumerator WaitToDestroy(GameObject bullet)
    {
        yield return new WaitForSeconds(1f);
        Destroy(bullet);
        gameManager.LoseLife();
    }



}
