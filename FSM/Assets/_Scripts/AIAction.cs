using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AIAction : MonoBehaviour
{
    protected EnemyBrain _brain;

    private void Awake() {
        _brain = GetComponentInParent<EnemyBrain>();
    }

    abstract public void TakeAction();

    
}
