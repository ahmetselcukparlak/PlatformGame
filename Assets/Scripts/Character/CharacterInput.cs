using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour, ICharacterInput
{
    private float _horizontal;
    private float _vertical;
    private bool _isJump;

    public float Horizontal { get => _horizontal; set => _horizontal = value; }
    public float Vertical { get => _vertical; set => _vertical = value; }
    public bool isJump { get => _isJump; set => _isJump = value; }



    private void Update()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
        _isJump = Input.GetButtonDown("Jump");
    }
}
