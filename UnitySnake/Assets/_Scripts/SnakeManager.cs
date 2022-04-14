using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
   private bool isAdd = true;
   public GameObject bodyPrefab;
   public List<GameObject> bodyList;
   public float moveDelay = 0.6f;

   public Vector3 moves = Vector3.zero;

   private void Start()
   {

      GameObject s = Instantiate(bodyPrefab);
      s.transform.position = new Vector3(0.0f, 0.0f, -1.2f);
      bodyList.Add(s);

      StartCoroutine(Move());
   }

   private void Update()
   {
      if(Input.GetKeyDown(KeyCode.LeftArrow))
      {
         moves = Vector3.left;
      }
      if (Input.GetKeyDown(KeyCode.RightArrow))
      {
         moves = Vector3.right;
      }
      if (Input.GetKeyDown(KeyCode.UpArrow))
      {
         moves = Vector3.up;
      }
      if (Input.GetKeyDown(KeyCode.DownArrow))
      {
         moves = Vector3.down;
      }

   }

   IEnumerator Move()
   {
      while (Test.isMove)
      {
         yield return new WaitForSeconds(moveDelay);
         
         if(!Test.isMove) break;

         if (isAdd)
         {
            bodyList.Insert(0, bodyList[bodyList.Count - 1]);
            bodyList[0].transform.position += moves;
            bodyList.RemoveAt(bodyList.Count - 1);
         }
         else
         {
            GameObject s = Instantiate(bodyPrefab);
            bodyList.Add(s);
            bodyList[1].transform.position = bodyList[0].transform.position + moves;

            isAdd = true;
         }

      }
   }

   public void Add()
   {
      isAdd = false;
   }
}
