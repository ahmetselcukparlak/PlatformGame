using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorService))]
public class CharacterJump : MonoBehaviour
{
    [SerializeField]
    private bool isJump = false;
    [SerializeField]
    private bool isDoubleJump = false;
    [SerializeField]
    private float jumpSpeed = 10;

    private Rigidbody2D rigidbody2D;
    private AnimatorService animatorService;
    private ICharacterInput characterInput;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animatorService = GetComponent<AnimatorService>();
        characterInput = new CharacterInput();
    }

    public void Update()
    {
        characterInput.SetInput();
        if (characterInput.isJump)
        {
            if (isJump && !isDoubleJump)
            {
                rigidbody2D.AddForce(Vector2.up * (jumpSpeed * 0.75f), ForceMode2D.Impulse);
                animatorService.Set("DoubleJump");
                isDoubleJump = true;
            }
            else if (isJump && isDoubleJump)
            {
                return;
            }
            else
            {
                rigidbody2D.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                animatorService.Set("Jump");
                isJump = true;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zemin")
        {
            isJump = false;
            isDoubleJump = false;
        }
    }
}
