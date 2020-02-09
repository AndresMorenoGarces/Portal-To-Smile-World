using System.Collections;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public PlatformType platformType = 0;
    private TurnState turnState = 0;

    public void SendCurrentPlatform(Vector3 currentDisplacement, PlatformType platformTypeReference)
    {
        if (this.transform.position == currentDisplacement && turnState == TurnState.Answered)
            platformTypeReference = this.platformType;
    }
}
