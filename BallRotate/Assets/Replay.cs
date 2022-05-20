using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Replay : MonoBehaviour
{
   public RotatePlane rp;
   public SaveKeyCodes skc;

   float time = 0.0f;
   int idx = 0;
   History his;

   void Start()
   {
      string json = File.ReadAllText("./Assets/success.json");
      his = JsonUtility.FromJson<History>(json);

      rp.NoInput = true;
      skc.Block = true;
   }


   void FixedUpdate()
   {
      time += 0.1f;
      if (time >= his.histories[idx].time)
      {
         Debug.Log("CUR: " + time);
         Debug.Log("SAV: " + his.histories[idx].time);
         switch (his.histories[idx].key)
         {
            case KeyCode.W:
               if (his.histories[idx].status) {
                  rp.WStart();
               } else {
                  rp.Stop();
               }
               break;

            case KeyCode.S:
               if (his.histories[idx].status) {
                  rp.SStart();
               } else {
                  rp.Stop();
               }
               break;

            case KeyCode.A:
               if (his.histories[idx].status) {
                  rp.AStart();
               } else {
                  rp.Stop();
               }
               break;

            case KeyCode.D:
               if (his.histories[idx].status) {
                  rp.DStart();
               } else {
                  rp.Stop();
               }
               break;
         }

         ++idx;

         if(idx >= his.histories.Count) {
            Debug.Log("Done!");
            this.enabled = false;
            return;
         }
      }
   }
}