using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyCamera : MonoBehaviour
{
    public GameObject _targetObj = null;
    public float _distance = 5.0f;
    public Vector3 _rotate = Vector3.zero;
    public Vector2 _moveVal = Vector2.zero;
    public float _speed = 3.0f;

    private bool _isRotateReady = false;

    private void Update()
    {
        Vector3 targetPos = _targetObj.transform.position;
        Vector3 cameraDir = targetPos - (targetPos + (Vector3.forward * _distance));
        Vector3 cameraPos = Quaternion.Euler(_rotate) * -cameraDir;

        transform.position = cameraPos + targetPos;
        transform.LookAt(targetPos);

        if(Vector2.zero != _moveVal) {
            _moveVal.Normalize();
            _targetObj.transform.position += Quaternion.Euler(_rotate) * new Vector3(-_moveVal.x, 0.0f, -_moveVal.y) * Time.deltaTime * _speed;
        }
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

    // 타겟 이동
    public void MoveTarget(InputAction.CallbackContext inContext)
    {
        _moveVal = inContext.ReadValue<Vector2>();

    }
}
