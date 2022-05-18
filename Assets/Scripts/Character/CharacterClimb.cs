using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterInput))]
[RequireComponent(typeof(AnimatorService))]
public class CharacterClimb : MonoBehaviour
{
    private ICharacterInput _characterInput;
    private AnimatorService animatorService;
    private Rigidbody2D rigidbody2D;

    private bool isLadder;
    private bool isGround;
    
    [SerializeField]
    private float climbSpeed;
    private bool isClimb = false;
    private float gravity = 3;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _characterInput = GetComponent<CharacterInput>();
        animatorService = GetComponent<AnimatorService>();
    }
    private void Update()
    {
        if (isLadder && Mathf.Abs(_characterInput.Vertical) > 0f)
        {
            if (isGround && _characterInput.Vertical < 0)
                isClimb = false;
            else
                isClimb = true;
        }
    }
    void FixedUpdate()
    {
        if (isClimb)
        {
            if (_characterInput.Vertical == 0) GetComponent<Animator>().speed = 0;
            else GetComponent<Animator>().speed = 1;
            animatorService.Set("Climb", true);
            rigidbody2D.gravityScale = 0;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _characterInput.Vertical * climbSpeed);
        }
        else
        {
            animatorService.Set("Climb", false);
            GetComponent<Animator>().speed = 1;
            rigidbody2D.gravityScale = gravity;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = false;
            isClimb = false;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zemin")
        {
            isGround = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zemin")
        {
            isGround = false;
        }
    }
}
