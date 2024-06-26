using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRadialBullet : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    //public GameObject projectilePrefab;
    public float timeToFire = 0.5f;         // the time enemy start to fire after spawn
    bool canFire = false;

    Vector2 startPoint;                     // starting position of the bullet
    const float radius = 1f;                // help us find move direction

    // bullet pool
    [SerializeField] GameObject bulletPool;         // bullet pool prefab
    GameObject bullets;                             // spawn the prefab above, we will interact with it

    // calculate the vector to shoot at player
    PlayerController playerController;
    Vector3 playerPos;

    private void Start()
    {
        // finds the player to check where they are
        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
            canFire = false;

        bullets = Instantiate(bulletPool, transform);
        StartCoroutine(ShootBullets(numberOfProjectiles));
    }

    private void Update()
    {
        startPoint = transform.position;

        // only update player position if they are still active
        if (playerController != null)
            playerPos = playerController.PlayerPos();

    }

    private IEnumerator ShootBullets(int numberOfProjectiles_)
    {
        yield return new WaitForSeconds(timeToFire);
        canFire = true;
        if (canFire)
        {
            float angleStep = 360 / numberOfProjectiles_;

            // use vector2.up and vector that point to player to create angle
            Vector2 bulDir = (playerPos - transform.position).normalized;
            float angle = Vector2.Angle(Vector2.up, bulDir);

            // because Vector2.Angle doesn't return the angle that is bigger than 180
            if (transform.position.x > playerPos.x)
                angle = 360 - angle;

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
                bullet.GetComponent<Rigidbody2D>().velocity = projectileMoveDirection;

                angle += angleStep;
            }

            canFire = false;
        }
    }
}
