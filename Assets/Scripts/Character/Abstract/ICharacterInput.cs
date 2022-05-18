using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterInput
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    public bool isJump { get; set; }
    public bool isAttack { get; set; }

    public void SetInput();
}
