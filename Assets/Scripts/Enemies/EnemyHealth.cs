using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : AHealth
{
    public EnemyHealth(float health, IAnimatorService animatorService) : base(health, animatorService)
    {
    }

    public override void Dead()
    {
        Debug.Log("Enemy �ld�");
    }

    public override void HasarAl()
    {
        Debug.Log("Hasar Al�yor Yeni Can : " + GetHealth());
    }
}
