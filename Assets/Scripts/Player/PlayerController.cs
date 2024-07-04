using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    // preventing player moving out of screen
    public float xmin, xmax, ymin, ymax;
}

// this script is a player's movement and shooting controller

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float speedFocus = 5.0f;                             // player holds shift to decrease speed
    public float speedNormal;

    public Boundary boundary;                                   // player can not move out of this boundary

    Rigidbody2D rb;
    [SerializeField] GameObject hitbox;                         // the red dot appears on player sprite
    [SerializeField] float fireRate = 0.1f;                     // bullet cooldown

    float curFireRate;
    float midBulletDelta = 0.2f;                                // bullet shooting style at player level 2 and 3
    float diagBulletDelta = 0.6f;                               // bullet shooting style at player level 3
    float diagBulletAngle = 30f;                                // bullet shooting style at player level 3

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedNormal = speed;
        curFireRate = fireRate;
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
        if (curFireRate <= 0 && Input.GetKey(KeyCode.Z) && !PauseMenu.isPause)
        {
            curFireRate = fireRate;

            // deicde which shooting style to use based on player level
            switch (GameManager.playerLevel)
            {
                case 1:
                    PlayerLevel1Shooting();
                    break;

                case 2:
                    PlayerLevel2Shooting();
                    break;

                case 3:
                    PlayerLevel2Shooting();
                    PlayerLevel3Shooting();
                    break;

                default:
                    PlayerLevel1Shooting();
                    break;
            }
        }
        else
        {
            curFireRate -= Time.deltaTime;

            if (curFireRate < 0)
                curFireRate = 0;
        }
    }

    void PlayerLevel1Shooting()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.playerShoot);
        GameObject bullet = PlayerBulletPooling.instance.GetPooledBullet();
        bullet.transform.rotation = Quaternion.Euler(0, 0, 90);
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * PlayerBullet.speed;
    }

    void PlayerLevel2Shooting()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.playerShoot);

        GameObject bulletLeft = PlayerBulletPooling.instance.GetPooledBullet();
        Vector2 bulletLeftPos = new Vector2(transform.position.x - midBulletDelta, transform.position.y);
        bulletLeft.transform.position = bulletLeftPos;
        bulletLeft.transform.rotation = Quaternion.Euler(0, 0, 90);
        bulletLeft.SetActive(true);
        bulletLeft.GetComponent<Rigidbody2D>().velocity = Vector2.up * PlayerBullet.speed;

        GameObject bulletRight = PlayerBulletPooling.instance.GetPooledBullet();
        Vector2 bulletRightPos = new Vector2(transform.position.x + midBulletDelta, transform.position.y);
        bulletRight.transform.position = bulletRightPos;
        bulletRight.transform.rotation = Quaternion.Euler(0, 0, 90);
        bulletRight.SetActive(true);
        bulletRight.GetComponent<Rigidbody2D>().velocity = Vector2.up * PlayerBullet.speed;
    }

    void PlayerLevel3Shooting()
    {
        // spawn and put the bullet into place
        GameObject bulletDiagLeft = PlayerBulletPooling.instance.GetPooledBullet();
        Vector2 bulletDiagLeftPos = new Vector2(transform.position.x - diagBulletDelta, transform.position.y);
        bulletDiagLeft.transform.position = bulletDiagLeftPos;
        bulletDiagLeft.SetActive(true);

        GameObject bulletDiagRight = PlayerBulletPooling.instance.GetPooledBullet();
        Vector2 bulletDiagRightPos = new Vector2(transform.position.x + diagBulletDelta, transform.position.y);
        bulletDiagRight.transform.position = bulletDiagRightPos;
        bulletDiagRight.SetActive(true);

        // diagonal bullet angle control then shoot with velocity
        if (hitbox.activeSelf)
        {
            bulletDiagLeft.transform.rotation = Quaternion.Euler(0, 0, 90);
            bulletDiagLeft.GetComponent<Rigidbody2D>().velocity = Vector2.up * PlayerBullet.speed;

            bulletDiagRight.transform.rotation = Quaternion.Euler(0, 0, 90);
            bulletDiagRight.GetComponent<Rigidbody2D>().velocity = Vector2.up * PlayerBullet.speed;
        }
        else
        {
            bulletDiagLeft.transform.rotation = Quaternion.Euler(0, 0, diagBulletAngle + 90);
            Vector2 bulletDiagLeftDir = UtilVector.RotateVector2(Vector2.up, diagBulletAngle);
            bulletDiagLeft.GetComponent<Rigidbody2D>().velocity = bulletDiagLeftDir * PlayerBullet.speed;

            bulletDiagRight.transform.rotation = Quaternion.Euler(0, 0, -diagBulletAngle + 90);
            Vector2 bulletDiagRightDir = UtilVector.RotateVector2(Vector2.up, 360 - diagBulletAngle);
            bulletDiagRight.GetComponent<Rigidbody2D>().velocity = bulletDiagRightDir * PlayerBullet.speed;
        }
    }

    // show player's position so enemies with target shooting style can shoot at player
    public Vector3 PlayerPos()
    {
        return transform.position;
    }
}
