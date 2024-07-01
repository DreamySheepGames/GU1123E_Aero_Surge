using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBulletDenseController : MonoBehaviour
{
    //[SerializeField] GameObject player;
    [SerializeField] int bulletAmount = 10;
    [SerializeField] float angleFormation = 35f;
    [SerializeField] float fireRate = 0.2f;
    [SerializeField] float burstTime = 1f;
    [SerializeField] float shootAfterSecond = 2f;
    bool canShoot = true;

    // calculate the vector to shoot at player
    PlayerController playerController;
    Vector3 playerPos;
    AudioSource audioSource;

    // bullet pool
    [SerializeField] GameObject bulletPool;
    GameObject bullets;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

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
        // only update player postition if they are not destroyed yet
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
                if (playerPos == null)
                    break;

                // vector that targets player
                Vector2 bulDir = (playerPos - transform.position).normalized;
                GameObject bul = bullets.GetComponent<BulletPooling>().GetBullet();
                bul.transform.position = transform.position;
                bul.GetComponent<TargetBullet>().SetMoveDir(bulDir);
                bul.SetActive(true);

                // extra vectors
                Vector2 bulDirLeft = UtilVector.RotateVector2(bulDir, -angleFormation);
                GameObject bulLeft = bullets.GetComponent<BulletPooling>().GetBullet();
                bulLeft.transform.position = transform.position;
                bulLeft.GetComponent<TargetBullet>().SetMoveDir(bulDirLeft);
                bulLeft.SetActive(true);

                Vector2 bulDirRight = UtilVector.RotateVector2(bulDir, angleFormation);
                GameObject bulRight = bullets.GetComponent<BulletPooling>().GetBullet();
                bulRight.transform.position = transform.position;
                bulRight.GetComponent<TargetBullet>().SetMoveDir(bulDirRight);
                bulRight.SetActive(true);

                audioSource.Play();

                yield return wait;
            }

            yield return new WaitForSeconds(burstTime);
        }
    }
}
