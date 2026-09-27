using UnityEngine;

public class ShooterBullet : Shooter
{
    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;


    public override void Shoot()
    {
        if (bulletSpawnPoint != null && bulletPrefab != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
    public override void Start()
    {

    }

    public override void Update()
    {

    }
}

