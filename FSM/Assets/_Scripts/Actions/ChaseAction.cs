using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class ChaseAction : AIAction
{
    public override void TakeAction()
    {
        Vector2 dir = Player.position - transform.position;
        _brain.Move(dir.normalized);
    }
}
