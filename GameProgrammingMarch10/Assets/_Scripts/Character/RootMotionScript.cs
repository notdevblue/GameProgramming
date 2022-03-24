using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RootMotionScript : MonoBehaviour
{
   private GameObject _parent = null;
   private Animator _animator = null;

   private void Start()
   {
      _parent = transform.parent.gameObject;
      Debug.Assert(null != _parent);
      _animator = GetComponent<Animator>();
      Debug.Assert(null != _animator);
   }

   // 루트 모션 처리 시 이 함수 호출함
   private void OnAnimatorMove()
   {
      if(null != _animator)
      {
         _parent.transform.rotation *= _animator.deltaRotation; // 4원소
         _parent.transform.position += _animator.deltaPosition;
      }
   }
}
