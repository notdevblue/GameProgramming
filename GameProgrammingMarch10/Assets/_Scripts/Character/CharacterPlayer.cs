using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterPlayer : CharactorBase
{
   private Vector2 _moveInput = Vector2.zero;
   // private StateController _stateCtrl = null;

   public bool ExistMoveInput { get { return Vector2.zero != _moveInput; } }
   public Vector2 MoveInputDir { get { return _moveInput; } }
   public float MoveMultiplier { get { return (_isWalk ? 0.5f : (_isRun ? 2.0f : 1.0f)); } }

   private bool _isWalk = false;
   private bool _isRun = false;
   private Vector2 _moveParam = Vector2.zero;
   private int _moveParamDirty = 0;
   private int _jump = 0;

   public Vector2 MoveParam {
      get { return _moveParam; }
      set {
         if(value != _moveParam)
         {
            _moveParam = value;
            _moveParamDirty = 3;
         }
      }
   }


   public void MoveInput(InputAction.CallbackContext InContext)
   {
      _moveInput = InContext.ReadValue<Vector2>();
      if(Vector2.zero != _moveInput)
      {
         _stateCtrl.ProcessMsg("Move");
      }
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
         _stateCtrl.ProcessMsg("Jump");
      }
   }

   protected override void Init()
   {
      base.Init();

      if ( null != _stateCtrl)
      {
         _stateCtrl.Init<StatePlayerIdle>();
      }
   }

   private void Update()
   {
      if(null != _stateCtrl)
      {
         _stateCtrl.Update();
      }

      if (0 < _moveParamDirty)
      {
         float lerpVal = Time.deltaTime * 10.0f;
         if(0 < (_moveParamDirty & 1))
         {
            float oldFwdVal = _animator.GetFloat("MoveForward");
            if(0.001f > Mathf.Abs(_moveParam.y - oldFwdVal))
            {
               _animator.SetFloat("MoveForward", _moveParam.y);
               _moveParamDirty &= ~1;
            }
            else
            {
               _animator.SetFloat("MoveForward", Mathf.Lerp(oldFwdVal, _moveParam.y, lerpVal));
            }
         }
         if (0 < (_moveParamDirty & 2))
         {
            float oldSideVal = _animator.GetFloat("MoveSide");
            if (0.001f > Mathf.Abs(_moveParam.x - oldSideVal))
            {
               _animator.SetFloat("Moveside", _moveParam.x);
               _moveParamDirty &= ~2;
            }
            else
            {
               _animator.SetFloat("MoveSide", Mathf.Lerp(oldSideVal, _moveParam.x, lerpVal));
            }
         }
      }
      #region 
      // // _animator.SetFloat("MoveForward", _moveInput.y);
      // float oldFwdVal = _animator.GetFloat("MoveForward");
      // float newFwdVal = (0.0f < _moveInput.y) ? (_isWalk ? 1.0f : (_isRun ? 3.0f : 2.0f)) : 0.0f;
      // _animator.SetFloat("MoveForward", Mathf.Lerp(oldFwdVal, newFwdVal, Time.deltaTime * 10.0f));

      // float oldSideVal = _animator.GetFloat("MoveSide");
      // float newSideVal = _moveInput.x * (_isWalk ? 0.5f : 1.0f);
      // _animator.SetFloat("MoveSide", Mathf.Lerp(oldSideVal, newSideVal, Time.deltaTime * 10.0f));

      // if(Vector2.zero != _moveInput)
      // {
      //    Camera currCam = Camera.current;
      //    if(null != currCam)
      //    {
      //       Vector3 camRot = currCam.transform.rotation.eulerAngles;
      //       Vector3 playerRot = transform.rotation.eulerAngles;
      //       playerRot.y = Mathf.LerpAngle(playerRot.y, camRot.y, Time.deltaTime * 10.0f);
      //       transform.rotation = Quaternion.Euler(playerRot);

      //       Vector3 moveDir = Quaternion.Euler(0.0f, camRot.y, 0.0f) * new Vector3(newSideVal, 0.0f, newFwdVal);

      //       // transform.position += moveDir * Time.deltaTime * MOVE_SPEED;
      //       _charCtrl.Move(moveDir * Time.deltaTime * MOVE_SPEED);
      //    }
      // }

      // switch(_jump)
      // {
      //    case 1:
      //       _animator.SetBool("IsJump", true);
      //       _jump = 2;
      //       break;
      //    case 2:
      //       if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
      //       {
      //          _animator.SetBool("IsJump", false);
      //          _jump = 0;
      //       }
      //       break;
      // }
      #endregion   
   }

   private void UpdateMoveParam(CharacterPlayer InPlayer)
   {
      float fwdMoveParam = InPlayer.MoveInputDir.y * InPlayer.MoveMultiplier;
      float sideMoveParam = InPlayer.MoveInputDir.x * Mathf.Min(1.0f, InPlayer.MoveMultiplier);
      InPlayer.MoveParam = new Vector2(sideMoveParam, fwdMoveParam);
   }

}