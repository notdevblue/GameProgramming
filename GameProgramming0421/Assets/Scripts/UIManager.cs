using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   List<Button> _buttons = new List<Button>();
   public List<Color> _colors = new List<Color>();

   private void Start()
   {
      FindAndAddLottoButtons();

      // _buttons.ForEach(e =>
      // {
      //    e.transform.GetChild(0).GetComponent<Text>().text = tempList[i++].ToString();
      // });
   }

   public void SetLotto()
   {
      int i = 0;

      (new Lotto()).LottoNumber(num => {
         if (_buttons.Count <= i)
            return;

         SetColor(num, _buttons[i]);
   
         Text txt = _buttons[i++].transform.GetChild(0).GetComponent<Text>();

         txt.text = num.ToString();
         // txt.text = (i - 1).ToString();
         txt.resizeTextForBestFit = true;
      });
   }


   public void SetColor(int num, Button btn)
   {
      btn.image.color = _colors[(int)(num / 10)];
   }

   public void FindAndAddLottoButtons()
   {
      GameObject[] temparr = GameObject.FindGameObjectsWithTag("LottoButtons");

      for (int i = 0; i < temparr.Length; ++i)
      {
         _buttons.Add(temparr[i].GetComponent<Button>());
      }
   }


}
