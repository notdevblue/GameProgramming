using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    [SerializeField] private List<AIAction> _actions = null;
    [SerializeField] private List<AITransition> _transitions = null;
    private EnemyBrain _enemyBrain;

    private void Awake() {
        _enemyBrain = GetComponentInParent<EnemyBrain>();
    }

    public void UpdateState()
    {
        // 해당 스테이트에 있는 액션 수행
        foreach(AIAction action in _actions) {
            action.TakeAction();
        }

        // 해당 스테이트 다른곳으로 넘어가야하는지 전의 검사
        bool result = false;

        foreach(AITransition transition in _transitions) {
            foreach(AIDecision decision in transition.decisions) {
                result = decision.MakeADecision();
                if(!result) break;
            }
            
            if(result) { //positive state
                if(transition.positiveResult != null) {
                    _enemyBrain.ChangeState(transition.positiveResult);
                }

            } else { // negative state
                if(transition.negativeResult != null) {
                    _enemyBrain.ChangeState(transition.negativeResult);
                }
            }
        }

    }
}
