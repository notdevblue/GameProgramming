using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterPlayer : MonoBehaviour
{
   private const float MOVE_SPEED = 3.0f;

   private Vector2 _moveInput = Vector2.zero;
   private Animator _animator = null;
   private CharacterController _charCtrl = null;
   // private StateController _stateCtrl = null;

   private bool _isWalk = false;
   private bool _isRun = false;
   private int _jump = 0;


   public void MoveInput(InputAction.CallbackContext InContext)
   {
      _moveInput = InContext.ReadValue<Vector2>();
   }

   public void WalkInput(InputAction.CallbackContext InContext)
   {
      _isWalk = InContext.performed;
   }

   public void RunInput(InputAction.CallbackContext InContext)
   {
      _isRun = InContext.performed;
   }

   public void JumpInput(InputAction.CallbackContext InContext)
   {
      if(InContext.performed)
      {
         _jump = 1;
      }
   }

   private void Start()
   {
      _animator = GetComponentInChildren<Animator>();
      _charCtrl = GetComponentInChildren<CharacterController>();
      Debug.Assert(null != _animator && null != _charCtrl); // 조건 안 맞으면 프로그램 중단

      // _stateCtrl = 
   }

   private void Update()
   {
      // _animator.SetFloat("MoveForward", _moveInput.y);
      float oldFwdVal = _animator.GetFloat("MoveForward");
      float newFwdVal = (0.0f < _moveInput.y) ? (_isWalk ? 1.0f : (_isRun ? 3.0f : 2.0f)) : 0.0f;
      _animator.SetFloat("MoveForward", Mathf.Lerp(oldFwdVal, newFwdVal, Time.deltaTime * 10.0f));

      float oldSideVal = _animator.GetFloat("MoveSide");
      float newSideVal = _moveInput.x * (_isWalk ? 0.5f : 1.0f);
      _animator.SetFloat("MoveSide", Mathf.Lerp(oldSideVal, newSideVal, Time.deltaTime * 10.0f));

      if(Vector2.zero != _moveInput)
      {
         Camera currCam = Camera.current;
         if(null != currCam)
         {
            Vector3 camRot = currCam.transform.rotation.eulerAngles;
            Vector3 playerRot = transform.rotation.eulerAngles;
            playerRot.y = Mathf.LerpAngle(playerRot.y, camRot.y, Time.deltaTime * 10.0f);
            transform.rotation = Quaternion.Euler(playerRot);

            Vector3 moveDir = Quaternion.Euler(0.0f, camRot.y, 0.0f) * new Vector3(newSideVal, 0.0f, newFwdVal);

            // transform.position += moveDir * Time.deltaTime * MOVE_SPEED;
            _charCtrl.Move(moveDir * Time.deltaTime * MOVE_SPEED);
         }
      }

      switch(_jump)
      {
         case 1:
            _animator.SetBool("IsJump", true);
            _jump = 2;
            break;
         case 2:
            if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
               _animator.SetBool("IsJump", false);
               _jump = 0;
            }
            break;
      }
   }
}