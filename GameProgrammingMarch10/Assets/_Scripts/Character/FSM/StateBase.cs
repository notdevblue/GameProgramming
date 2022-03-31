using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase
{
   public virtual string StateName { get { return ""; } }
   public virtual int Priority { get { return 0; } }
   public virtual string AniName { get { return ""; } }

   public virtual void Enter(StateController InCtrl) { }
   public virtual void Exit(StateController InCtrl) { }
   public virtual void Update(StateController InCtrl) { }
   public virtual void AniEntered(StateController InCtrl) { }
   public virtual bool ReadyExit(StateController InCtrl) { return true; }
   public virtual void ProcessMsg(StateController InCtrl, string InMsg) { }

   public bool IsAniPlaying(StateController InCtrl)
   {
      return InCtrl.Anim.GetCurrentAnimatorStateInfo(0).IsName(AniName);
   }

   public bool IsAniExited(StateController InCtrl)
   {
      return InCtrl.IsAniEntered && (false == IsAniPlaying(InCtrl));
   }


}
