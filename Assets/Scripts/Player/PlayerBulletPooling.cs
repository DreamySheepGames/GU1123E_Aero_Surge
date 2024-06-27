using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPooling : MonoBehaviour
{
    public static PlayerBulletPooling instance { get; set; }

    List<GameObject> pooledBullet = new List<GameObject>();
    int amountToPool = 2;
    [SerializeField] GameObject bulletPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
        // return the bullet that is not active
        for (int i = 0; i < pooledBullet.Count; i++)
        {
            if (!pooledBullet[i].activeInHierarchy)
            {
                pooledBullet[i].transform.position = transform.position;    // return the bullet to the head of the plane
                return pooledBullet[i];
            }
        }

        // if we are out of bullets
        if (AreAllBulletActive())
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            bullet.SetActive(false);
            pooledBullet.Add(bullet);
            return bullet;
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
