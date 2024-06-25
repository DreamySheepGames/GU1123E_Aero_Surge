using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBulletPooling : MonoBehaviour
{
    //public static TargetBulletPooling instance;
    [SerializeField] GameObject pooledBullet;
    List<GameObject> bullets;
    bool notEnoughBulletsInPool = true;
    int amountToPool = 10;

    private void Start()
    {
        //if (instance != null && instance != this)
        //    Destroy(this.gameObject);
        //else
        //    instance = this;

        bullets = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject bullet = Instantiate(pooledBullet);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
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

        // if we don't have any then spawn, add in pool, then return the bullet that just spawned;
        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            pooledBullet.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }


}
