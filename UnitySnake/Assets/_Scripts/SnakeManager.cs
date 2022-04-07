using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
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
      while (true)
      {
         yield return new WaitForSeconds(moveDelay);

         bodyList[0].transform.position += moves;
      }
   }
}
