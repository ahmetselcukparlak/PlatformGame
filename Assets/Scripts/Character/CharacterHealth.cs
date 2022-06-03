using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : AHealth
{
    public CharacterHealth(float health, IAnimatorService animatorService, HealthBar HealthBar) : base(health, animatorService,HealthBar)
    {
    }

    public override void HasarAl()
    {
        _animatorService.Set("Hurt");
        Debug.Log("Hasar Aldık, Yeni Can : " + GetHealth());
        HealthBar.SetHealth(GetHealth());
    }
    public override void Dead()
    {
        _animatorService.Set("Die");
        CharacterService.Instance.DisableCharacter();
        HealthBar.SetHealth(GetHealth());

        Debug.Log("Oyun Bitti Karakter Öldü");
    }
}
