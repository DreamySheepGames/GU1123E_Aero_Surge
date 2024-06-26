using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBigBulletController : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject projectilePrefab;
    public float timeToFire = 0.5f;         // the time enemy start to fire after spawn
    //bool canFire = false;

    Vector2 startPoint;                     // starting position of the bullet
    const float radius = 1f;                // help us find move direction

    private void Start()
    {
        StartCoroutine(ShootBullets(numberOfProjectiles));
    }

    private void Update()
    {
        startPoint = transform.position;
    }

    private IEnumerator ShootBullets(int numberOfProjectiles_)
    {
        yield return new WaitForSeconds(timeToFire);
        //canFire = true;
        //if (canFire)
        //{
        float angleStep = 360 / numberOfProjectiles_;
        float angle = 0;


        // number of directions
        for (int i = 0; i < numberOfProjectiles_; i++)
        {
            // direction vector calculations
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject bullet = Instantiate(projectilePrefab, startPoint, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = projectileMoveDirection;

            angle += angleStep;
        }

        //    canFire = false;
        //}
    }
}
