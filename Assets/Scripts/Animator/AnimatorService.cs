using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorService : MonoBehaviour,IAnimatorService
{
    private Animator mAnimator;

    public void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    public void Set(string name)
    {
        mAnimator.SetTrigger(name);
    }
    public void Set(string name, bool state)
    {
        mAnimator.SetBool(name, state);
    }
    public void ResetTrigger(string name)
    {
        mAnimator.ResetTrigger(name);
    }
}
