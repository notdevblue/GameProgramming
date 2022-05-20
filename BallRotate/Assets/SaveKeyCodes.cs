using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveKeyCodes : MonoBehaviour
{
   public bool Block = false;

   public static SaveKeyCodes instance;
   public List<KeyHistory> savedKeyQueue = new List<KeyHistory>();

   float time = 0.0f;

   private void Awake()
   {
      instance = this;
   }

   IEnumerator Start()
   {
      yield return new WaitForSeconds(10.0f);
      if (Block) yield break;

      History his = new History(savedKeyQueue);

      File.WriteAllText("./Assets/success.json", JsonUtility.ToJson(his));
      Debug.Log("Sucecss!");
   }

   private void FixedUpdate()
   {
      time += 0.1f;
   }

   private void OnCollisionEnter(Collision other)
   {
      if (other.transform.CompareTag("BALL"))
      {
         savedKeyQueue.Clear();
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
   }


   public void AddKey(KeyCode key, bool status)
   {
      savedKeyQueue.Add(new KeyHistory(key, status, time));
   }
}

[Serializable]
class History
{
   public List<KeyHistory> histories;

   public History(List<KeyHistory> histories) => this.histories = histories;
}


[Serializable]
public class KeyHistory
{
   public KeyCode key;
   public bool status;
   public float time;

   public KeyHistory(KeyCode key, bool status, float time)
   {
      this.key = key;
      this.status = status;
      this.time = time;
   }
}
