using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    public AHealth health;

    void Start()
    {
        health = new EnemyHealth(100, null);
    }
}
