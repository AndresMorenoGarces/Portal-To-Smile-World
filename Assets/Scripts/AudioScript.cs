using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioScript instance;
    public AudioSource[] characterAudioSource;
    public AudioSource diceAudioSource;

    public AudioClip[] diceAudioClips;

    public void PlayerAudio(PlayerState playerState, int currentPlayer)
    {
            if (playerState == PlayerState.Idle)
                 characterAudioSource[currentPlayer].Stop();
            else if (playerState == PlayerState.Moving)
                characterAudioSource[currentPlayer].Play();
    }
    public void DiceAudioState(int audioNum)
    {
        diceAudioSource.PlayOneShot(diceAudioClips[audioNum]); 
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }
}
