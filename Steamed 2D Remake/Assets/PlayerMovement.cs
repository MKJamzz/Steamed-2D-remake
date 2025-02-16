using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float maxSpeed;
    public float changeSpeed;
    public float xSpeed;
    public float ySpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxSpeed = 5;
        changeSpeed = 30;
    }

    // Update is called once per frame
    void Update()
    {
        float xInp = Input.GetAxisRaw("Horizontal");
        float yInp = Input.GetAxisRaw("Vertical");

        addMovement(xInp,ref xSpeed);
        addMovement(yInp,ref ySpeed);

        rb.linearVelocity = new Vector2(xSpeed, ySpeed);
    }


    void addMovement(float inp, ref float speed)
    {
        if(inp > 0)     //If on the right side
        {
            if (speed < maxSpeed)
            {
                speed += changeSpeed * Time.deltaTime;
            }
            else if(speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else if(inp < 0)    //If on the left side
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
        else
        {
            if(speed <= 0.5 && speed >= -0.5)
            {
                speed = 0;
            }
            else if(speed > 0.5)
            {
                speed -= changeSpeed * Time.deltaTime;
            }
            else if(speed < -0.5){
                speed += changeSpeed * Time.deltaTime;
            }
        }
    }
}
