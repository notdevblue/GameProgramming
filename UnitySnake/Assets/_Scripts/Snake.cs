using UnityEngine;

public class Snake : MonoBehaviour
{
   public SnakeManager snm;

   private void Start()
   {
      snm = GameObject.FindWithTag("snm").GetComponent<SnakeManager>();
   }

   private void Update()
   {
      if (transform.position.x > 14.0f || transform.position.y > 14.0f || transform.position.x < 0.0f || transform.position.y < 0.0f)
      {
         GameOver();
         Test.isMove = false;
      }
   }

   public void GameOver()
   {
      GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("food"))
      {
         Debug.Log(other.name);
         snm.Add();
         other.gameObject.SetActive(false);
      }
   }
}