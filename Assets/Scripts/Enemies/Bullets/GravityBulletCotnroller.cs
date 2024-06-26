using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBulletCotnroller : MonoBehaviour
{
    //public GameObject projectilePrefab;
    // bullet pool
    [SerializeField] GameObject bulletPool;         // bullet pool prefab
    GameObject bullets;                             // spawn the prefab above, we will interact with it

    float fireRate = 0.1f;
    int bulletsPerBurst = 15;        // Number of bullets per burst
    float burstPauseDuration = 1f;   // Pause for 1 second before continue to burst
    float timeBeforeShoot = 0.02f;

    bool isFire = true;

    private void Start()
    {
        bullets = Instantiate(bulletPool, transform);

        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        //yield return new WaitForSeconds(timeBeforeShoot);

        while (isFire && bullets != null)
        {
            for (int i = 0; i < bulletsPerBurst; i++)
            {
                //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                GameObject bullet = bullets.GetComponent<BulletPooling>().GetBullet();
                bullet.SetActive(true);

                // Wait for fireRate seconds before shooting the next bullet
                yield return new WaitForSeconds(fireRate);
            }

            // Wait for burstPauseDuration seconds before starting the next burst
            yield return new WaitForSeconds(burstPauseDuration);
        }
    }
}
