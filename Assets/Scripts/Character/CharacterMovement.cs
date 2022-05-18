using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterInput))]
[RequireComponent(typeof(AnimatorService))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 10;
    [SerializeField]
    private float speed;
    private float getScale;

    private Rigidbody2D rigidbody2D;
    private ICharacterInput characterInput;
    private AnimatorService animatorService;
    private void Awake()
    {
        speed = maxSpeed;
    }
    void Start()
    {
        getScale = GetComponent<Transform>().localScale.x;
        rigidbody2D = GetComponent<Rigidbody2D>();
        characterInput = GetComponent<CharacterInput>();
        animatorService = GetComponent<AnimatorService>();
    }

    void Update()
    {
        rigidbody2D.velocity = new Vector3(characterInput.Horizontal * speed, rigidbody2D.velocity.y, 0);

        if (characterInput.Horizontal < 0) GetComponent<Transform>().localScale = new Vector2(-getScale, getScale);
        else if (characterInput.Horizontal > 0) GetComponent<Transform>().localScale = new Vector2(getScale, getScale);

        if (characterInput.Horizontal != 0) animatorService.Set("Run", true);
        else animatorService.Set("Run", false);
    }
}
