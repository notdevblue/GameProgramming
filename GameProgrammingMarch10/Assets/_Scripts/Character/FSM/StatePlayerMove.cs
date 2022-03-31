using UnityEngine;

public class StatePlayerMove : StateBase
{
   public override string StateName { get { return "StatePlayerMove"; } }
   public override int Priority { get { return 1; } }
   public override string AniName { get { return "Move"; } }

   public override void Enter(StateController InCtrl)
   {
      UpdateMoveParam(InCtrl.GetCharacter<CharacterPlayer>());
   }
   public override void Exit(StateController InCtrl)
   {
      InCtrl.GetCharacter<CharacterPlayer>().MoveParam = Vector2.zero;
   }

   public override void Update(StateController InCtrl)
   {
      CharacterPlayer player = InCtrl.GetCharacter<CharacterPlayer>();

      if (player.ExistMoveInput)
      {
         UpdateMoveParam(player);
         Camera currCam = Camera.main;
         Debug.Assert(null != currCam);

         Vector3 camRot = currCam.transform.rotation.eulerAngles;
         // Vector3
      }
   }
   public override void AniEntered(StateController InCtrl) { }
   public override bool ReadyExit(StateController InCtrl) { return true; }
   public override void ProcessMsg(StateController InCtrl, string InMsg)
   {
      if ("Jump" == InMsg)
      {
         InCtrl.ChangeState<StatePlayerJump>();
      }
   }
}