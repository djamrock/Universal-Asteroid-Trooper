using UnityEngine;

public class ShooterBullet : Shooter
{
    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;


    public override void Shoot()
    {
        if (bulletSpawnPoint != null && bulletPrefab != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // creates each bullet when shoot is presses. line reads as "create(bullet gameObject, Vector3 position on the bullet, Quanternion rotation of the bullet)
        }
    }
    public override void Start()
    {

    }

    public override void Update()
    {

    }
}

