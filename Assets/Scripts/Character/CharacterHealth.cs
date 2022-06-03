using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : AHealth
{
    public CharacterHealth(float health, IAnimatorService animatorService, HealthBarBehaviour Healthbar) : base(health, animatorService, Healthbar)
    {
    }

    public override void HasarAl()
    {
        _animatorService.Set("Hurt");
        //Healthbar.SetHealth(GetHealth(),100);
        Debug.Log("Hasar Aldık, Yeni Can : " + GetHealth());
        
    }
    public override void Dead()
    {
        _animatorService.Set("Die");
        CharacterService.Instance.DisableCharacter();
        Debug.Log("Oyun Bitti Karakter Öldü");
    }
}
