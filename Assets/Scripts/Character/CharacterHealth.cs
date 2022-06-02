using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : AHealth
{
    public CharacterHealth(float health, IAnimatorService animatorService) : base(health, animatorService)
    {

    }

    public override void HasarAl()
    {
        _animatorService.Set("Hurt");
        Debug.Log("Hasar Aldýk, Yeni Can : " + GetHealth());
    }

    public override void Dead()
    {
        _animatorService.Set("Die");

        Debug.Log("Oyun Bitti Karakter Öldü");

    }
}
