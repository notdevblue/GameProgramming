using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlane : MonoBehaviour
{
   public bool NoInput = false;

   public GameObject[] planes = new GameObject[0];
   public Rigidbody[] balls = new Rigidbody[0];

   public float rotRand = 0.1f;
   public float rotMul;

   public Vector3 curRot;

   private Vector3[] defBallsPos;

   void Start()
   {
      Rand();
      defBallsPos = new Vector3[balls.Length];

      for (int i = 0; i < balls.Length; ++i)
      {
         defBallsPos[i] = balls[i].transform.position;
      }
   }

   public void WStart()
   {
      Rotate(Vector3.right * rotMul);
   }
   public void SStart()
   {
      Rotate(Vector3.left * rotMul);
   }
   public void AStart()
   {
      Rotate(Vector3.forward * rotMul);
   }
   public void DStart()
   {
      Rotate(Vector3.back * rotMul);
   }
   public void Stop()
   {
      StopRotate();
   }

   public void W()
   {
      if (Input.GetKeyDown(KeyCode.W)) {
         Rotate(Vector3.right * rotMul);
         SaveKeyCodes.instance.AddKey(KeyCode.W, true);
         StartCoroutine(CheckKeyUp(KeyCode.W));
      }
   }

   public void S()
   {
      if (Input.GetKeyDown(KeyCode.S)) {
         Rotate(Vector3.left * rotMul);
         SaveKeyCodes.instance.AddKey(KeyCode.S, true);
         StartCoroutine(CheckKeyUp(KeyCode.S));
      }
   }

   public void A()
   {
      if (Input.GetKeyDown(KeyCode.A)) {
         Rotate(Vector3.forward * rotMul);
         SaveKeyCodes.instance.AddKey(KeyCode.A, true);
         StartCoroutine(CheckKeyUp(KeyCode.A));
      }
   }

   public void D()
   {
      if (Input.GetKeyDown(KeyCode.D)) {
         Rotate(Vector3.back * rotMul);
         SaveKeyCodes.instance.AddKey(KeyCode.D, true);
         StartCoroutine(CheckKeyUp(KeyCode.D));
      }
   }

   private KeyCode curkey;

   void Update()
   {
      if (!NoInput) {
         W();
         S();
         A();
         D();
      }


      if (Input.GetKeyDown(KeyCode.R)) {
         Reset();
      }

      for (int i = 0; i < planes.Length; ++i)
      {
         planes[i].transform.eulerAngles += curRot * Time.deltaTime;
      }
   }


   IEnumerator CheckKeyUp(KeyCode up)
   {
      while (!Input.GetKeyUp(up)) { yield return null; }
      StopRotate();
      SaveKeyCodes.instance.AddKey(up, false);
   }


   private void Rand(int idx = 0)
   {
      if (idx >= planes.Length) return;

      planes[idx].transform.eulerAngles = new Vector3(Random.Range(-rotRand, rotRand), 0.0f, Random.Range(-rotRand, rotRand));
      Rand(++idx);
   }


   private void Rotate(Vector3 addRot)
   {
      curRot = addRot;
   }

   private void StopRotate()
   {
      curRot = Vector3.zero;
   }

   private void Reset()
   {
      for (int i = 0; i < balls.Length; ++i)
      {
         balls[i].transform.position = defBallsPos[i];
         balls[i].velocity = Vector3.zero;
         balls[i].rotation = Quaternion.identity;
         balls[i].angularVelocity = Vector3.zero;
      }

      for (int i = 0; i < planes.Length; ++i)
      {
         planes[i].transform.rotation = Quaternion.identity;
      }
   }
}
