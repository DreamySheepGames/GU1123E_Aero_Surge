using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBulletController : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    //public GameObject projectilePrefab;
    public float timeToFire = 1f;                   // the time enemy start to fire after spawn

    Vector2 startPoint;                             // starting position of the bullet
    const float radius = 1f;                        // the radius of the circle, or the length of vector, can affect bullet speed
    bool hasFired = false;
    AudioSource audioSource;

    // bullet pool
    [SerializeField] GameObject bulletPool;         // bullet pool prefab
    GameObject bullets;                             // spawn the prefab above, we will interact with it

    private void Start()
    {
        // we can't use clip from the AudioManager because there are other enemies using this same shooting script but different sound clip.
        // for example: AudioManager.Instance.PlaySFX(AudioManager.Instance.enemy1Shoot), but what if enemy 2 use this same script but different clip (enemy2Shoot)
        // we will use AudioManger to play this audio source, the AudioManager will manage the volume when there are many same audio source.
        audioSource = GetComponent<AudioSource>();

        bullets = Instantiate(bulletPool, transform);
    }

    private void Update()
    {
        timeToFire -= Time.deltaTime;

        if (timeToFire <= 0 && !hasFired)
        {
            hasFired = true;
            startPoint = transform.position;
            SpawnBullet(numberOfProjectiles);
        }
    }

    void SpawnBullet(int numberOfProjectiles_)
    {
        float angleStep = 360 / numberOfProjectiles_;
        float angle = 0;

        AudioManager.Instance.PlayEnemyShoot(audioSource);

        for (int i = 0; i < numberOfProjectiles_; i++)
        {
            // direction vector calculations
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            //GameObject bullet = Instantiate(projectilePrefab, startPoint, Quaternion.identity);
            GameObject bullet = bullets.GetComponent<BulletPooling>().GetBullet();
            bullet.SetActive(true);

            bullet.transform.rotation = Quaternion.Euler(0, 0, 360 - angle + 90);
            bullet.GetComponent<Rigidbody2D>().velocity = projectileMoveDirection;

            angle += angleStep;
        }
    }

    
}
