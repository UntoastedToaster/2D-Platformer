using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    private bool canDash = true;
    public float speed = 10;
    public float jumpforce = 10;
    public float max_jumpforce = 10;
    public float max_speed = 10;
    public float stopping_force = 5;
    public float max_jumps = 1;
    private float multijump = 1;
    public float Nextjumpreducer = 0;
    public float dashforce = 2;
    public float dashtime = 0.5f;
    private Rigidbody2D rigidbody2D;
    private Animator _animator;
    private float scaleX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        multijump = max_jumps;
        jumpforce = max_jumpforce;
        _animator = GetComponent<Animator>();
        scaleX = transform.localScale.x;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (direction.x !=0)
        {
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
        }

        if (rigidbody2D.linearVelocityY < 0)
        {
            _animator.SetBool("IsFalling", true);
        }
        else
        {
            _animator.SetBool("IsFalling", false);
        }

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
        if(canDash!)
        {
            return;
        }
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
            if (multijump > 0)
            {
                multijump--;
                jumpforce = jumpforce - Nextjumpreducer;
            }
            else if (multijump == 0)
            {
                canJump = false;
            }
        }
        
    }

    private void OnDash()
    {
        if (canDash)
        {
            canDash = false;
            rigidbody2D.AddForce(new Vector2(direction.x, 0) * dashforce, ForceMode2D.Impulse);
            if (direction.x == 0)
            {
                rigidbody2D.AddForce(Vector2.right * dashforce, ForceMode2D.Impulse);
            }

            StartCoroutine(ResetDash(dashtime));
        }
    }
    IEnumerator ResetDash(float timetoRest)
    {
        yield return new WaitForSeconds(timetoRest);
        canDash = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        multijump = max_jumps;
        jumpforce = max_jumpforce;
    }
}
