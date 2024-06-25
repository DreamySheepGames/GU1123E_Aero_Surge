using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    // preventing player moving out of screen
    public float xmin, xmax, ymin, ymax;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float speedFocus = 5.0f;     // player holds shift to decrease speed
    public float speedNormal;

    public Boundary boundary;
    //public GameObject bullet;           // spawn bullets

    Rigidbody2D rb;
    [SerializeField] GameObject hitbox;
    [SerializeField] float nextFire = 0f;                     // bullet cooldown
    [SerializeField] float fireRate = 0.1f;                     // bullet cooldown

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedNormal = speed;
    }

    private void Update()
    {
        PlayerShooting();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerBoundary();
    }

    void PlayerMovement()
    {
        // Movement
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            movement += Vector3.up;
        if (Input.GetKey(KeyCode.DownArrow))
            movement += Vector3.down;
        if (Input.GetKey(KeyCode.LeftArrow))
            movement += Vector3.left;
        if (Input.GetKey(KeyCode.RightArrow))
            movement += Vector3.right;

        // focus
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedFocus;
            hitbox.SetActive(true);
        }
        else
        {
            hitbox.SetActive(false);
            speed = speedNormal;
        }

        // Move the player at a constant speed
        transform.position += movement * speed * Time.deltaTime;
    }

    void PlayerBoundary()
    {
        if (transform.position.x < boundary.xmin)
        {
            Vector3 xbound = new Vector3(boundary.xmin, transform.position.y, transform.position.z);
            transform.position = xbound;
        }

        if (transform.position.x > boundary.xmax)
        {
            Vector3 xbound = new Vector3(boundary.xmax, transform.position.y, transform.position.z);
            transform.position = xbound;
        }

        if (transform.position.y < boundary.ymin)
        {
            Vector3 ybound = new Vector3(transform.position.x, boundary.ymin, transform.position.z);
            transform.position = ybound;
        }

        if (transform.position.y > boundary.ymax)
        {
            Vector3 ybound = new Vector3(transform.position.x, boundary.ymax, transform.position.z);
            transform.position = ybound;
        }
    }

    void PlayerShooting()
    {
        // player presses Z to fire
        if (Time.time > nextFire && Input.GetKey(KeyCode.Z))
        {
            nextFire = Time.time + fireRate;

            //Instantiate(bullet, gun.transform.position, bullet.transform.rotation);

            // set a bullet to be active
            GameObject bullet = PlayerBulletPooling.instance.GetPooledBullet();
            if (bullet != null)
            {
                bullet.SetActive(true);
            }
        }
    }

    public Vector3 PlayerPos()
    {
        return transform.position;
    }
}
