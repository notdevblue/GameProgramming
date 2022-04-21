using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LottoManager : MonoBehaviour
{
   private List<int> lottoList = new List<int>();

   private void Start()
   {
      LottoCreate();
   }

   public void LottoCreate()
   {
      for (int i = 1; i < 46; ++i)
      {
         lottoList.Add(i);
      }

      // MySort();
      // BubbleSort();
      // DoLotto();
      LottoNumber();
   }

   public void MySort()
   {
      List<int> temp = new List<int>();

      for (int i = 0; i < 45; ++i)
      {
         temp.Add(lottoList[lottoList.Count - i - 1]);
      }

      lottoList = temp;

      for (int i = 0; i < 45; ++i)
      {
         Debug.Log(lottoList[i]);
      }
      
   }

   public void BubbleSort()
   {
      for (int i = 0; i < lottoList.Count - 1; ++i)
      {
         for (int j = i + 1; j < lottoList.Count; ++j)
         {
            if (lottoList[i] < lottoList[j])
            {
               int temp = lottoList[i];
               lottoList[i] = lottoList[j];
               lottoList[j] = temp;
            }
         }
      }

      for (int i = 0; i < lottoList.Count; ++i)
      {
         Debug.Log(lottoList[i]);
      }
   }


   public void DoLotto(int countWithBonusNumber = 7)
   {
      List<int> lottobak = lottoList;
      List<int> result = new List<int>();

      for (int i = 0; i < countWithBonusNumber; ++i)
      {
         int randIdx = Random.Range(0, lottobak.Count);
         int res = lottobak[randIdx];
      
         lottobak.RemoveAt(randIdx);
      
         result.Add(res);
      }

      for (int i = 0; i < result.Count - 1; ++i)
      {
         Debug.Log("Lotto: " + result[i]);
      }

      Debug.Log("Bonus: " + result[result.Count - 1]);
   }

   public void LottoNumber()
   {
      List<int> result = new List<int>();

      for (int i = 0; i < 7; ++i)
      {
         int index = Random.Range(0, lottoList.Count);

         result.Add(GetCount(ref result, lottoList[index]));  
      }

      for (int i = 0; i < result.Count; ++i)
      {
         Debug.Log(result[i]);
      }
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