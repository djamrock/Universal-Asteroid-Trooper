using UnityEngine;



public class ShooterBullet : Shooter
{
    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;


    public override void Shoot()
    {
        if (bulletSpawnPoint != null && bulletPrefab != null)
        {
            // create gameObject(object, position, rotation)
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // creates each bullet when shoot is presses. 
        }
    }
    public override void Start()
    {

    }

    public override void Update()
    {

    }
}

