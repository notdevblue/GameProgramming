using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
   // system, editor, resources 는 유니티가 사용함
   public GameObject       gridPrefab;
   public List<GameObject> gridList;

   public int size = 15;
   public float blinkDelay = 0.01f;
   public float denst = 0.1f;

   public Color up;
   public Color ground;
   public Color down;

   private void Start()
   {
      StartCoroutine(CreateGrid());
      StartCoroutine(Blink());
      StartCoroutine(Wave());




   }  

   int temp = 0;

   IEnumerator CreateGrid()
   {
      GameObject p = new GameObject("parent");
      yield return new WaitForSeconds(0.2f);

      for (int i = 0; i < size; ++i)
      {
         for (int j = 0; j < size; ++j)
         {

            GameObject g = Instantiate(gridPrefab);
            g.transform.position = new Vector3(i, j, 0);

            // g.GetComponent<MeshRenderer>().material.color = (i + j) % 2 == 0 ? one : two;
            g.transform.SetParent(p.transform);
            gridList.Add(g);
         }
      }

      Vector3 first = gridList.First().transform.position;
      Vector3 last = gridList.Last().transform.position;
      Vector3 target = first + ((last - first) / 2.0f);
      target.z = -20.0f;

      Camera.main.transform.position = target;
   }

   IEnumerator Blink()
   {
      while(true)
      {
         yield return null;

         for (int i = 0; i < gridList.Count; ++i)
         {
            MeshRenderer mesh = gridList[i].GetComponent<MeshRenderer>();
            Vector3 pos = gridList[i].transform.position;
            
            if (pos.z >= -0.2f && pos.z <= 0.2f)
            {
               mesh.material.color = ground;
            }
            else if (pos.z > -0.2f)
            {
               mesh.material.color = down;
            }
            else
            {
               mesh.material.color = up;
            }
         }
      }
   }

   IEnumerator Wave()
   {
      while (true)
      {
         for (int i = 0; i < gridList.Count; ++i)
         {
            Vector3 target = gridList[i].transform.position;
            target.z = Mathf.Sin(Time.time + ((int)(i / size) * denst))
                     + Mathf.Sin(Time.time + ((i % size) * denst));
            gridList[i].transform.position = target;
         }

         yield return null;
      }

   }

}
