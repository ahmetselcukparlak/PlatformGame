using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    public AHealth health;
    public static EnemyService Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        health = new EnemyHealth(100, null);
    }
}
