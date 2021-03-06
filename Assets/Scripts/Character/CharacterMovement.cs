using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorService))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float _speed;

    public float Speed
    {
        get { return _speed; }
        set
        {
            if (value > 0)
                _speed = value;
            else
                _speed = 0;
        }
    }

    private Rigidbody2D rigidbody2D;
    private ICharacterInput characterInput;
    private AnimatorService animatorService;
    private void Awake()
    {
        _speed = maxSpeed;
    }
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        characterInput = new CharacterInput();
        animatorService = GetComponent<AnimatorService>();
    }

    void Update()
    {
        characterInput.SetInput();
        rigidbody2D.velocity = new Vector3(characterInput.Horizontal * _speed, rigidbody2D.velocity.y, 0);

        if (characterInput.Horizontal < 0) GetComponent<SpriteRenderer>().flipX = true;
        else if (characterInput.Horizontal > 0) GetComponent<SpriteRenderer>().flipX = false;

        if (characterInput.Horizontal != 0) animatorService.Set("Run", true);
        else animatorService.Set("Run", false);
    }
}
