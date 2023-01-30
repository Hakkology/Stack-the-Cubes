using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{
    // movement speed of the Camera
    float _cameraMovementSpeed = 1f;


    // moving the Camera back a little
    public void moveCamera() {

        Vector3.Lerp(transform.position, -transform.forward, _cameraMovementSpeed);
        Vector3.Lerp(transform.position, -transform.up/2, _cameraMovementSpeed);

        //transform.position += Vector3.back * 0.2f * _cameraMovementSpeed;
        //transform.position += Vector3.up * 0.05f * _cameraMovementSpeed;
    }
}
