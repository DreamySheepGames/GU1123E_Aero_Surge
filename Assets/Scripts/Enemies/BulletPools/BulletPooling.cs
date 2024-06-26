using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    [SerializeField] GameObject pooledBullet;
    List<GameObject> bullets;
    bool notEnoughBulletsInPool = true;
    //int amountToPool = 10;

    private void Start()
    {
        bullets = new List<GameObject>();

        // we don't spawn the bullets in start in case the enemy spawn the pool when it is not
        // in the wanted postition. (Enemy at point A but bullets are spawn at point B)

        //for (int i = 0; i < amountToPool; i++)
        //{
        //    GameObject bullet = Instantiate(pooledBullet);
        //    bullet.SetActive(false);
        //    bullets.Add(bullet);
        //}
    }

    public GameObject GetBullet()
    {
        // if we have bullet then return the bullet that is not active
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    bullets[i].transform.position = transform.position;
                    return bullets[i];
                }
            }
        }

        // if we don't have any then spawn, add in pool, then return the bullet that just spawned
        // we don't actually need the notEnoughBulletsInPool condition
        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet, transform.position, Quaternion.identity);
            pooledBullet.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }


}
