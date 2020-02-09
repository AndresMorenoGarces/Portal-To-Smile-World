using UnityEngine;

class Character : MonoBehaviour
{
    private PlayerState playerState = 0;
    private Quaternion rotationFrom;
    private Quaternion rotationTo;
    private Transform temporalTargetDisplacement;
    private Transform targetDisplacement;

    public void PlayerMove(Transform specificVoidCharacterTransform, Transform[] wayPoints, int temporalCurrentTarget, int currentTarget) 
    {
        AudioScript.instance.PlayerAudio(playerState);
        AnimationScript.instance.PlayerAnimations(playerState);
        PlayerRotate();
        temporalTargetDisplacement = wayPoints[temporalCurrentTarget];
        targetDisplacement = wayPoints[currentTarget];
        if (playerState == PlayerState.Moving)
            specificVoidCharacterTransform.position = Vector3.MoveTowards(specificVoidCharacterTransform.position, temporalTargetDisplacement.position, 1 * Time.deltaTime);
        else if (playerState == PlayerState.Idle)
            specificVoidCharacterTransform.position = targetDisplacement.position;
        void PlayerRotate()
        {
            rotationFrom = Quaternion.LookRotation(specificVoidCharacterTransform.forward);
            if (specificVoidCharacterTransform.position != temporalTargetDisplacement.position)
                rotationTo = Quaternion.LookRotation(temporalTargetDisplacement.position - specificVoidCharacterTransform.position);
            else if (currentTarget < wayPoints.Length - 1)
                rotationTo = Quaternion.LookRotation(wayPoints[temporalCurrentTarget + 1].position - specificVoidCharacterTransform.position);
            specificVoidCharacterTransform.rotation = Quaternion.Slerp(rotationFrom, rotationTo, 4f * Time.deltaTime);
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
