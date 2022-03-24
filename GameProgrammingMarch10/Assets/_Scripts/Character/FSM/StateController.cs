using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController
{
   private Animator _anim = null;
   private Dictionary<System.Type, StateBase> _states = new Dictionary<System.Type, StateBase>();
   private StateBase _currState = null;
   private StateBase _reserveState = null;
   private bool _isAniEnter = false;

#if UNITY_EDITOR
   private string _log = "";
   private int _logCount = 0;
   private int _logStatus = 0;

   public bool IsLogAdded { get { return 0 < _logStatus; } }
   public string Log {get { return _log; } }
#endif

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

   private void Update()
   {
      if(null != _reserveState)
      {
         // ChagneState(_reserveState, true);
      }

      // if(false == _isAniEnter && _anim.GetCurrentAnimatorStateInfo(0).IsName)
      {

      }
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
      // if(false == _currState.ReadyExit(this))
      {

      }
   }



}
