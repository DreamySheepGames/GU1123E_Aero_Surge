using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBulletCotnroller : MonoBehaviour
{
    public GameObject projectilePrefab;
    float fireRate = 0.1f;
    int bulletsPerBurst = 15;        // Number of bullets per burst
    float burstPauseDuration = 1f;   // Pause for 1 second before continue to burst

    bool isFire = true;

    private void Start()
    {
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        while (isFire)
        {
            for (int i = 0; i < bulletsPerBurst; i++)
            {
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                // Wait for fireRate seconds before shooting the next bullet
                yield return new WaitForSeconds(fireRate);
            }

            // Wait for burstPauseDuration seconds before starting the next burst
            yield return new WaitForSeconds(burstPauseDuration);
        }
    }
}
