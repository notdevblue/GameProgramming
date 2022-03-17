using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyCamera : MonoBehaviour
{
    public GameObject _targetObj = null;
    public float _distance = 5.0f;
    public Vector3 _rotate = Vector3.zero;
    public Vector3 _offset = Vector3.zero;
    public float _speed = 3.0f;

    private bool _isRotateReady = false;

    private void Update()
    {
        if(_targetObj == null) return;

        Vector3 targetPos = _targetObj.transform.position + _offset;
        Vector3 cameraDir = targetPos - (targetPos + (Vector3.forward * _distance));
        Vector3 cameraPos = Quaternion.Euler(_rotate) * -cameraDir;

        transform.position = cameraPos + targetPos;
        transform.LookAt(targetPos);
    }

    // 카메라 회전 처리
    public void RotateCamera(InputAction.CallbackContext inContext)
    {
        if(!_isRotateReady) return;
        
        Vector2 inputAxis = inContext.ReadValue<Vector2>();
        float pitch = _rotate.x + inputAxis.y;
        _rotate.x = Mathf.Min(80.0f, Mathf.Abs(pitch)) * Mathf.Sign(pitch); // Sign -> 부호를 돌려줌
        _rotate.y += inputAxis.x;
    }

    // 카메라 회전 준비 처리
    public void ReadyCameraRotate(InputAction.CallbackContext inContext)
    {
        _isRotateReady = inContext.performed;
    }

    public void ZoomCamera(InputAction.CallbackContext inContext) {
        Vector2 wheelVar = inContext.ReadValue<Vector2>();
        _distance = Mathf.Clamp(_distance + wheelVar.y * 0.1f, 1.0f, 10.0f);
    }
}
