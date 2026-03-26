using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    public float speed = 10;
    public float jumpforce = 10;
    public float max_speed = 10;
    public float stopping_force = 5;
    private Rigidbody2D rigidbody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
        HandleMaxSpeed();
        PlayerStopping();
    }

    private void MovePlayer()
    {
        rigidbody2D.AddForce(new Vector2(direction.x, 0) * speed);
    }

    private void HandleMaxSpeed()
    {
        if (rigidbody2D.linearVelocityX >= max_speed)
        {
            rigidbody2D.linearVelocityX = max_speed;
        }
        else if (rigidbody2D.linearVelocityX <= -max_speed)
        {
            rigidbody2D.linearVelocityX = -max_speed;
        }
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX, 0) * stopping_force);
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (canJump)
        { 
        rigidbody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        canJump = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
