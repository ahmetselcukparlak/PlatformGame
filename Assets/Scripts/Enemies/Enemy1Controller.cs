using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    private enum State
    {
        Walking,
        Knockback,
        Dead
    }

    private State currentState;

    private void Update()
    {
        switch (currentState)
        {
            case State.Walking:
                UpdateWalkingState();
                break;
            case State.Knockback:
                UpdateKanockbackState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;

        }
    }

    private void EnterWalkingState()
    {

    }
    private void UpdateWalkingState()
    {

    }
    private void ExitWalkingState()
    {

    }


    private void EnterKnockbackState()
    {

    }
    private void UpdateKanockbackState()
    {

    }
    private void ExitKanockbackState()
    {

    }


    private void EnterDeadState()
    {

    }
    private void UpdateDeadState()
    {

    }
    private void ExitDeadState()
    {

    }

}
