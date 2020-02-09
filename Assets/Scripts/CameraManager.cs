using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform cam;
    public Transform[] camParentObjects;

    public void TypesOfCameras(ActiveCamera activeCamera)
    { // 0: The firstPerson player camera. 1: The diceCam is active with this num. 2: The third person player camera is active. 3: The TVcam is active in this turn.
        cam.transform.SetParent(camParentObjects[(int)activeCamera]);
        cam.position = camParentObjects[(int)activeCamera].position;
        cam.eulerAngles = camParentObjects[(int)activeCamera].eulerAngles;
    }
    public void TypesOfCameras(ActiveCamera activeCamera, Transform currentPlayer)
    { // 0: The firstPerson player camera. 1: The diceCam is active with this num. 2: The third person player camera is active. 3: The TVcam is active in this turn.
        cam.transform.SetParent(camParentObjects[(int)activeCamera]);
        cam.position = camParentObjects[(int)activeCamera].position;
        cam.eulerAngles = camParentObjects[(int)activeCamera].eulerAngles;
    }
}