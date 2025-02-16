using System.Xml.XPath;
using Unity.VisualScripting;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public bool chasing;
    public bool attacking;
    public float noticeRange;
    public float attackCooldown;

    public float maxSpeed;
    public float changeSpeed;
    private float ySpeed;
    private float xSpeed;

    GameObject player;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();

        attacking = false;
        chasing = false;

        noticeRange = 7f;
        attackCooldown = 3f;

        maxSpeed = 4f;
        changeSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, player.transform.position); //Distance between player and enemy

        if(dist <= noticeRange)
        {
            chase(transform.position.y, player.transform.position.y, ref ySpeed);
            chase(transform.position.x, player.transform.position.x, ref xSpeed);
        }
        else
        {
            slowDown();
        }

        rb.linearVelocity = new Vector2(xSpeed, ySpeed);
    }
    void chase(float enemyPos, float playerPos, ref float speed)
    {
        if (enemyPos < playerPos)     //If on the right side
        {
            if (speed < maxSpeed)
            {
                speed += changeSpeed * Time.deltaTime;
            }
            else if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else if (enemyPos > playerPos)    //If on the left side
        {
            if (speed > -maxSpeed)
            {
                speed -= changeSpeed * Time.deltaTime;
            }
            else if (speed <= -maxSpeed)
            {
                speed = -maxSpeed;
            }
        }
    }

    void slowDown()
    {
            if (xSpeed <= 0.5 && xSpeed >= -0.5)
            {
                xSpeed = 0;
            }
            else if (xSpeed > 0.5)
            {
                xSpeed -= changeSpeed * Time.deltaTime;
            }
            else if (xSpeed < -0.5)
            {
                xSpeed += changeSpeed * Time.deltaTime;
            }

            if (ySpeed <= 0.5 && ySpeed >= -0.5)
            {
                ySpeed = 0;
            }
            else if (ySpeed > 0.5)
            {
                ySpeed -= changeSpeed * Time.deltaTime;
            }
            else if (ySpeed < -0.5)
            {
                ySpeed += changeSpeed * Time.deltaTime;
            }
    }
}
