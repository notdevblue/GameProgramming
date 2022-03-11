using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AIDecision : MonoBehaviour
{
    private void Awake()
    {
        
    }

    public abstract bool MakeADecision();
}
