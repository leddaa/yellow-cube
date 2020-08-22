using UnityEngine;

public class CompleteTrigger : MonoBehaviour
{
    public GoalManager completeManager;

    private void Awake()
    {
        completeManager = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER).GetComponent<GoalManager>();
    }

    private void OnTriggerEnter()
    {
        completeManager.EnterGoal();
    }
}
