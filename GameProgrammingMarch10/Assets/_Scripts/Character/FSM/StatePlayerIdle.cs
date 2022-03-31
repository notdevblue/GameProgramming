using UnityEngine;

public class StatePlayerIdle : StateBase
{
   public override string StateName { get { return "StatePlayerIdle"; } }
   public override int Priority { get { return 0; } }
   public override string AniName { get { return "Idle"; } }

   public override void Enter(StateController InCtrl)
   {

   }
   
   public override void Exit(StateController InCtrl)
   {

   }
   
   public override void Update(StateController InCtrl)
   {

   }
   
   public override void AniEntered(StateController InCtrl)
   {
      
   }
   
   public override bool ReadyExit(StateController InCtrl)
   {
      return true;
   }

   public override void ProcessMsg(StateController InCtrl, string InMsg)
   {
      if ("Move" == InMsg)
      {
         InCtrl.ChangeState<StatePlayerMove>();
      }

      else if ("Jump" == InMsg)
      {
         InCtrl.ChangeState<StatePlayerJump>();
      }
   }
}