using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newLookForPlayerStateData", menuName = "Data/State Data/Loof For Player State")]
public class D_LookForPlayer : ScriptableObject
{
    public int amaountOfTurns = 2;

    public float timeBetweenTurns = 0.75f;
}
