using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyCamera : MonoBehaviour
{
	private const float MOVE_SPEED = 10.0f;

	public GameObject TargetObj = null;
	public float Distance = 5.0f;
	public Vector3 Rotate = Vector3.zero;
	public Vector3 Offset = Vector3.zero;

	private bool _isRotateReady = false;
	
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (null != TargetObj)
		{
			Vector3 targetPos = TargetObj.transform.position + Offset;
			Vector3 cameraDir = Vector3.forward * Distance;
			Vector3 cameraPos = Quaternion.Euler(Rotate) * cameraDir;
			transform.position = targetPos + cameraPos;
			transform.LookAt(targetPos);
		}
	}

	// 카메라 회전 처리
	public void RotateCamera(InputAction.CallbackContext InContext)
	{
		if (_isRotateReady)
		{
			Vector2 inputAxis = InContext.ReadValue<Vector2>() * 0.15f;
			float pitch = Rotate.x + inputAxis.y;
			Rotate.x = Mathf.Min(80.0f, Mathf.Abs(pitch)) * Mathf.Sign(pitch);
			Rotate.y += inputAxis.x;
		}
	}

	// 카메라 회전 준비 처리
	public void ReadyCameraRotate(InputAction.CallbackContext InContext)
	{
		_isRotateReady = InContext.performed;
	}

	// 카메라 줌
	public void ZoomCamera(InputAction.CallbackContext InContext)
	{
		Vector2 wheelVal = InContext.ReadValue<Vector2>();
		Distance = Mathf.Clamp(Distance + wheelVal.y * 0.001f, 1.0f, 10.0f);
	}
}
