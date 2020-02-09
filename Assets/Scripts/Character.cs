using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    private PlayerState playerState = 0;
    private Quaternion rotationFrom;
    private Quaternion rotationTo;
    private Transform temporalTargetDisplacement;

    public void PlayerMove(Transform specificVoidCharacterTransform, Transform[] wayPoints, int temporalCurrentTarget, int currentTarget, int __playerTurn) 
    {
        AudioScript.instance.PlayerAudio(playerState, __playerTurn);
        AnimationScript.instance.PlayerAnimations(playerState, __playerTurn);
            //print(temporalTargetDisplacement.position);

        temporalTargetDisplacement = wayPoints[temporalCurrentTarget];
        if (playerState == PlayerState.Moving)
            specificVoidCharacterTransform.position = Vector3.MoveTowards(specificVoidCharacterTransform.position, temporalTargetDisplacement.position, 10 * Time.deltaTime);
        else if (playerState == PlayerState.Idle)
            StartCoroutine(TimeToRest());



            //rotationFrom = Quaternion.LookRotation(specificVoidCharacterTransform.forward);
            //if (specificVoidCharacterTransform.position != temporalTargetDisplacement.position)
            //    rotationTo = Quaternion.LookRotation(temporalTargetDisplacement.position - specificVoidCharacterTransform.position);
            //else if (currentTarget < wayPoints.Length - 1)
            //    rotationTo = Quaternion.LookRotation(wayPoints[temporalCurrentTarget + 1].position - specificVoidCharacterTransform.position);
            //specificVoidCharacterTransform.rotation = Quaternion.Slerp(rotationFrom, rotationTo, 4f * Time.deltaTime);
        
        IEnumerator TimeToRest()
        {
            yield return new WaitForSeconds(1.5f);
            playerState = PlayerState.Moving;
        }
    }

    public Vector3 PlayerResituate(int turnOfPlayer, Transform[] playersTransforms)
    {
        float playerTransformX = playersTransforms[turnOfPlayer].transform.position.x;
        float playerTransformZ = playersTransforms[turnOfPlayer].transform.position.z;
        switch (turnOfPlayer)
        {
            case 0:
                playerTransformX = playersTransforms[turnOfPlayer].transform.position.x + 2f; playerTransformZ = playersTransforms[turnOfPlayer].transform.position.z + 2f; break;
            case 1:
                playerTransformX = playersTransforms[turnOfPlayer].transform.position.x - 2f; playerTransformZ = playersTransforms[turnOfPlayer].transform.position.z + 2f; break;
            case 2:
                playerTransformX = playersTransforms[turnOfPlayer].transform.position.x + 2f; playerTransformZ = playersTransforms[turnOfPlayer].transform.position.z - 2f; break;
            case 3:
                playerTransformX = playersTransforms[turnOfPlayer].transform.position.x - 2f; playerTransformZ = playersTransforms[turnOfPlayer].transform.position.z - 2f; break;
        }
        return playersTransforms[turnOfPlayer].transform.position;
    }
}
