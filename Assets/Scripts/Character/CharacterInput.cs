using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : ICharacterInput
{
    private float _horizontal;
    private float _vertical;
    private bool _isJump;
    private bool _isAttack;

    public float Horizontal { get => _horizontal; set => _horizontal = value; }
    public float Vertical { get => _vertical; set => _vertical = value; }
    public bool isJump { get => _isJump; set => _isJump = value; }
    public bool isAttack { get => _isAttack; set => _isAttack = value; }

    public void SetInput()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
        _isJump = Input.GetButtonDown("Jump");
        _isAttack = Input.GetButtonDown("Fire1");
    }
}
