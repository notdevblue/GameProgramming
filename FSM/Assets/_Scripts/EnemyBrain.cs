using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AIState currentState;

    public void Move(Vector2 dir) {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void ChangeState (AIState state) {
        currentState = state;
    }

    private void Update() {
        currentState.UpdateState();
    }


}
