using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPooling : MonoBehaviour
{
    public static PlayerBulletPooling instance;

    List<GameObject> pooledBullet = new List<GameObject>();
    int amountToPool = 2;
    [SerializeField] GameObject bulletPrefab;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            bullet.SetActive(false);
            pooledBullet.Add(bullet);
        }
    }

    // get the bullet that is not active in the pool
    public GameObject GetPooledBullet()
    {
        // check if we are out of bullets
        if (AreAllBulletActive())
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            bullet.SetActive(false);
            pooledBullet.Add(bullet);
        }

        for (int i = 0; i < pooledBullet.Count; i++)
        {
            if (!pooledBullet[i].activeInHierarchy)
            {
                pooledBullet[i].transform.position = transform.position;    // return the bullet to the head of the plane
                return pooledBullet[i];
            }
        }

        return null;
    }

    bool AreAllBulletActive()
    {
        foreach(GameObject bul in pooledBullet)
        {
            if (!bul.activeSelf)
                return false;
        }
        return true;
    }
}
