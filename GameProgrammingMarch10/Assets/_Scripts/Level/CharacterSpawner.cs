using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
   [Serializable]
   public struct PartData
   {
      public PartsControl.PartType PType;
      public string Path;
   }

   public string CharacterPath = "";
   public PartData[] Parts = null;

   private void Start()
   {
      CharacterManager.Instance.SpawnPlayer(
         CharacterPath, transform.position, transform.rotation);

      GameObject player = CharacterManager.Instance.Player;
      if(null != player)
      {
         PartsControl partsCtl = player.GetComponent<PartsControl>();
         if(null != partsCtl)
         {
            foreach(PartData data in Parts)
            {
               partsCtl.EquipPart(data.PType, data.Path);
            }
         }
      }
   }
}
