using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public static AnimationScript instance;
    public Animator[] PlayerAnimator;
    public Animator tapAnimator;
    public Animator diceAnimator;
    public Animator tvAnimator;

    public void PlayerAnimations(PlayerState playerState, int _playerturn)
    {
        if (playerState == PlayerState.Idle)
            PlayerAnimator[_playerturn].Play("Waiting");
        else if (playerState == PlayerState.Moving)
            PlayerAnimator[_playerturn].Play("Running");
    }
    public void TapAnimation(bool isActive)
    {
        if (isActive)
            tapAnimator.Play("TapChanceColor");
        else
            tapAnimator.StopPlayback();
    }
    public void DiceAnimations(bool isActive)
    {
        if (isActive)
            diceAnimator.Play("DicePreRotation");
        else
            diceAnimator.StopPlayback();
    }
    public void TVAnimations(bool isActive)
    {
        if (isActive)
            tvAnimator.Play("TVAnimation");
        else
            tvAnimator.StopPlayback();
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }
}
