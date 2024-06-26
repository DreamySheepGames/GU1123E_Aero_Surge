using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBulleController : MonoBehaviour
{
    //[SerializeField] GameObject player;
    [SerializeField] int bulletAmount = 10;
    [SerializeField] float fireRate = 0.2f;
    [SerializeField] float burstTime = 1f;
    [SerializeField] float shootAfterSecond = 2f;
    bool canShoot = true;

    // calculate the vector to shoot at player
    PlayerController playerController;
    Vector3 playerPos;

    // bullet pool
    [SerializeField] GameObject bulletPool;
    GameObject bullets;


    private void Start()
    {
        // finds the player to check where they are
        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
            canShoot = false;

        // spawns its own bullet pool
        bullets = Instantiate(bulletPool, transform);

        // wait until fire
        StartCoroutine(FireTartget());
    }

    private void Update()
    {
        if (playerController != null)
            playerPos = playerController.PlayerPos();
    }

    IEnumerator FireTartget()
    {
        WaitForSeconds wait = new WaitForSeconds(shootAfterSecond);
        yield return wait;

        wait = new WaitForSeconds(fireRate);

        // shoot an amount of bullets with a fire rate then wait for the next burst
        while (canShoot)
        {
            for (int i = 0; i < bulletAmount; i++)
            {
                // vector that targets player
                Vector2 bulDir = (playerPos - transform.position).normalized;
                GameObject bul = bullets.GetComponent<BulletPooling>().GetBullet();
                bul.transform.position = transform.position;
                bul.GetComponent<TargetBullet>().SetMoveDir(bulDir);
                bul.SetActive(true);

                yield return wait;
            }

            yield return new WaitForSeconds(burstTime);
        }
    }
}
