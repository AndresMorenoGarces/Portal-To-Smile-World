using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform cam;
    public Transform[] camParentObjects;

    public void TypesOfCameras(ActiveCamera activeCamera)
    { // 0: The diceCam is active with this num. 1: The TVcam is active in this turn.
        cam.transform.SetParent(camParentObjects[(int)activeCamera]);
        cam.localPosition = new Vector3(0, 0, -10);
        cam.localEulerAngles = Vector3.zero;
        cam.localScale = Vector3.one;
    }
    public void TypesOfCameras(ActiveCamera activeCamera, Transform currentPlayer)
    { // 2: The firstPerson player camera. 3: The third person player camera is active.
        cam.transform.SetParent(currentPlayer);
        cam.localScale = Vector3.one;
        switch ((int) activeCamera)
        {
            case 2:
                cam.localPosition = new Vector3(0, 1.5f, 2);
                cam.localEulerAngles = new Vector3(15, 180, 0);
                break;
            case 3:
                cam.localPosition = new Vector3(0, 3.8f, -4);
                cam.localEulerAngles = new Vector3(15, 0, 0);
                break;
        }
    }
}