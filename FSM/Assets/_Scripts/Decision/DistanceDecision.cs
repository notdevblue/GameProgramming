using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class DistanceDecision : AIDecision
{
    [Range(0, 20)]
    [SerializeField] private float _distance;
    public override bool MakeADecision()
    {
        float distance = Vector3.Distance(Player.position, transform.position);
        return distance < _distance;
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos() {
        if(UnityEditor.Selection.activeObject == gameObject) {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _distance);
            Gizmos.color = Color.white;
        }
    }


    #endif
}
