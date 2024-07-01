using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRadialBulletSpawner : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    //public GameObject projectilePrefab;
    public float timeToFire = 1.2f;         // the time enemy start to fire after spawn
    bool hasFired = false;
    public float fireRate = 0.2f;
    public bool clockWise = true;

    Vector2 startPoint;                     // starting position of the bullet
    const float radius = 1f;                // help us find move direction
    public float angleTilt = 10f;           // spin the spawn point
    AudioSource audioSource;

    // bullet pool
    [SerializeField] GameObject bulletPool;         // bullet pool prefab
    GameObject bullets;                             // spawn the prefab above, we will interact with it

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bullets = Instantiate(bulletPool, transform);
        StartCoroutine(ShootBullets(numberOfProjectiles));
    }

    // Update is called once per frame
    void Update()
    {
        startPoint = transform.position;
        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 0.25f);
    }

    private IEnumerator ShootBullets(int numberOfProjectiles_)
    {
        yield return new WaitForSeconds(timeToFire);
        hasFired = true;
        float angle = 0;

        while (hasFired)
        {
            float angleStep = 360 / numberOfProjectiles_;

            // number of directions
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
                bullet.transform.rotation = Quaternion.Euler(0, 0, 360 - angle);
                bullet.GetComponent<Rigidbody2D>().velocity = projectileMoveDirection;

                angle += angleStep;
            }

            AudioManager.Instance.PlayEnemyShoot(audioSource);

            // spinning
            if (clockWise)
                angle -= angleTilt;
            else
                angle += angleTilt;

            yield return new WaitForSeconds(fireRate);
        }
    }
}
