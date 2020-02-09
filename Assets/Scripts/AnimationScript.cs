using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public static AnimationScript instance;
    public Animator PlayerAnimator;
    public Animator tapAnimator;
    public Animator diceAnimator;
    public Animator tvAnimator;

    public void PlayerAnimations(PlayerState playerState)
    {
        if (playerState == PlayerState.Idle)
            PlayerAnimator.Play("Waiting");
        else if (playerState == PlayerState.Moving)
            PlayerAnimator.Play("Running");
    }
    public void TapAnimation(bool isActive)
    {
        if (isActive)
            tapAnimator.Play("TapChanceColor");
        else
        {
            tapAnimator.StopPlayback();
            tapAnimator.Rebind();
        }
    }
    public void DiceAnimations(bool isActive)
    {
        if (isActive)
            diceAnimator.Play("DicePreRotation");
        else
        {
            diceAnimator.StopPlayback();
            diceAnimator.Rebind();
        }
    }
    public void TVAnimations(bool isActive)
    {
        if (isActive)
            tvAnimator.Play("TVAnimation");
        else
        {
            tvAnimator.StopPlayback();
            tvAnimator.Rebind();
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }
}
