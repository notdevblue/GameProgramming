using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController
{
   private CharactorBase _character = null;
   private Animator _anim = null;
   private Dictionary<System.Type, StateBase> _states = new Dictionary<System.Type, StateBase>();
   private StateBase _currState = null;
   private StateBase _reserveState = null;
   private bool _isAniEnter = false;
   
   public bool IsAniEntered { get { return _isAniEnter; } }


#if UNITY_EDITOR
   private string _log = "";
   private int _logCount = 0;
   private bool _logDirty = false;

   public bool IsLogDirty { get { return _logDirty; } }

   public string Log { get { return _log; } }
#endif

   public CharactorBase Character {get { return _character; } }
   public Animator Anim {get { return _anim; } }

   public StateController(Animator animator)
   {
      _anim = animator;
   }

   public void Init<T>() where T : StateBase, new()
   {
      _states.Clear();
      _currState = new T();
      _states.Add(typeof(T), _currState);
      _reserveState = null;
      _isAniEnter = true;
#if UNITY_EDITOR
      // AddLog("Init State: " + _currState.Statename);
#endif
   }

   public void Update()
   {
      if(null != _reserveState)
      {
         ChangeState(_reserveState, true);
      }

      if(false == _isAniEnter)
      {
         AnimatorStateInfo asi = _anim.GetCurrentAnimatorStateInfo(0);
         if(asi.IsName(_currState.AniName))
         {
            _currState.AniEntered(this);
            _isAniEnter = true;
         }
      }

      _currState.Update(this);
   }

   public void ChangeState<T>(bool InReserve = true) where T : StateBase, new()
   {
      if(typeof(T) == _currState.GetType())
      {
         return;
      }

      StateBase nextState;
      if(false == _states.TryGetValue(typeof(T), out nextState))
      {
         nextState = new T();
         _states.Add(typeof(T), nextState);
      }

      ChangeState(nextState, InReserve);
   }

   private void ChangeState(StateBase InNextState, bool InReserve)
   {
      if(false == _currState.ReadyExit(this))
      {
         if(InReserve && ( null == _reserveState || _reserveState.Priority <
                           InNextState.Priority))
         {
            _reserveState = InNextState;
         }
         return;
      }

      string oldAniName = _currState.AniName;
      _currState.Exit(this);
      _currState = InNextState;
      _currState.Enter(this);
      _reserveState = null;
      _isAniEnter = (oldAniName == _currState.AniName);
   }

   public void ProcessMsg(string InMsg)
   {
      _currState.ProcessMsg(this, InMsg);
   }

   public T GetCharacter<T>() where T : CharactorBase
   {
      return (T)_character;
   }


}
