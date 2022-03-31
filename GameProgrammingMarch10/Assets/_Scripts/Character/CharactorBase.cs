using UnityEngine;

public class CharactorBase : MonoBehaviour
{
   protected Animator _animator = null;
   protected CharacterController _charCtrl = null;
   protected StateController _stateCtrl = null;

   public virtual Animator Anim {get { return _animator; } }
   public virtual CharacterController CharCtrl {get { return _charCtrl; } }
   public virtual StateController FSM { get { return _stateCtrl; } }
   public virtual float MoveSpeed { get { return 3.0f; } }

   private void Start()
   {
      Init();
   }

   protected virtual void Init()
   {
      _animator = GetComponentInChildren<Animator>();
      Debug.Assert(null != _animator);
      _charCtrl = GetComponentInChildren<CharacterController>();
      Debug.Assert(null != CharCtrl);

      _stateCtrl = new StateController(this.Anim);
   }
}