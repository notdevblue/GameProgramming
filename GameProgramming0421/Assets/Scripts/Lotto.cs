using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotto
{
   private List<int> lottoList = new List<int>();


   public Lotto()
   {
      LottoCreate();
   }

   public void LottoCreate()
   {
      for (int i = 1; i < 46; ++i)
      {
         lottoList.Add(i);
      }
   }

   public List<int> LottoNumber(System.Action<int> callback)
   {
      List<int> result = new List<int>();

      for (int i = 0; i < 7; ++i)
      {
         int index = Random.Range(0, lottoList.Count);

         result.Add(GetCount(ref result, lottoList[index]));
      }

      for (int i = 0; i < result.Count; ++i)
      {
         callback(result[i]);
      }

      return result;
   }

   public int GetCount(ref List<int> list, int num)
   {
      for (int i = 0; i < list.Count; ++i)
      {
         if (list[i] == num)
         {
            int index = Random.Range(0, lottoList.Count);
            num = GetCount(ref list, lottoList[index]);
         }
      }

      return num;
   }
}