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
        
    
      

        if(Input.GetButton("Fire1") && Time.time >= nextFireTime && gameManager != null)
        {
            Test2();
        }


    }

  

    void Test2()
    {
        nextFireTime = Time.time + weaponData.fireRate;
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject newGameObject = (GameObject)Instantiate(bulletPrefab, mouseRay.origin, transform.rotation);
        Rigidbody rb = newGameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
      
            rb.velocity = mouseRay.direction * weaponData.bulletSpeed;
        }
        gameManager.NumOfBullets--;
    }

     
}
