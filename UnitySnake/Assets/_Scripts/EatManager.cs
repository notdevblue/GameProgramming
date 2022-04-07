using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatManager : MonoBehaviour
{
   public GameObject foodPrefab;
   public float foodSpawnDelay = 1.0f;
   public int size = 15;
   public List<GameObject> foods = new List<GameObject>();

   private void Start()
   {
      CreateFood();
      StartCoroutine(EnableFood());
   }

   void CreateFood()
   {
      GameObject p = new GameObject("parent");


      for (int i = 0; i < size; ++i)
      {
         for (int j = 0; j < size; ++j)
         {
            GameObject f = Instantiate(foodPrefab);
            f.transform.position = new Vector3(i, j, -1.2f);
            f.transform.SetParent(p.transform);
            f.SetActive(false);
            foods.Add(f);
         }
      }
   }

   IEnumerator EnableFood()
   {
      while(true)
      {
         yield return new WaitForSeconds(foodSpawnDelay);
         List<GameObject> temp = foods.FindAll(e => !e.activeSelf);
         temp[Random.Range(0, temp.Count)].SetActive(true);
      }
   }
}
