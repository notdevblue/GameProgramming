using UnityEngine;

public class StatePlayerJump : StateBase
{
   public override string StateName { get { return "StatePlayerJump"; } }
   public override int Priority { get { return 2; } }
   public override string AniName { get { return "Jump"; } }

   public override void Enter(StateController InCtrl)
   {
      InCtrl.Anim.SetBool("IsJump", true);
   }
   public override void Exit(StateController InCtrl) { }
   public override void Update(StateController InCtrl)
   {
      CharacterPlayer player = InCtrl.GetCharacter<CharacterPlayer>();
      if(IsAniExited(InCtrl))
      {
         if(InCtrl.GetCharacter<CharacterPlayer>().ExistMoveInput)
         {
            InCtrl.ChangeState<StatePlayerMove>();
         }
         else
         {
            InCtrl.ChangeState<StatePlayerIdle>();
         }
      }
   }
   public override void AniEntered(StateController InCtrl)
   {
      InCtrl.Anim.SetBool("IsJump", false);
   }
   public override bool ReadyExit(StateController InCtrl)
   {
      return IsAniExited(InCtrl);
   }
   public override void ProcessMsg(StateController InCtrl, string InMsg) { }
}