using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UADE.IA.FSM;

public class LeaderSeekState<T> : FSMState<T>
{
    //Leader _leader;
    //LeaderAnimations _leaderAnimations;

    CharacterAIController leaderAIController;

    FSM<T> _fsm;
    T _patrolState;
    T _attackState;

    public LeaderSeekState(CharacterAIController _leaderAIController, FSM<T> fsm,
    T patrolState, T attackState)
    {

        leaderAIController = _leaderAIController;

        _fsm = fsm;
        _patrolState = patrolState;
        _attackState = attackState;
    }

    public override void Awake()
    {
        Debug.Log("Leader Seek State Awake");
    }

    public override void Execute()
    {
        Debug.Log("Leader Seek State Execute");
        SeekBehaviour();
    }

    public override void Sleep()
    {
        Debug.Log("Leader Seek State Sleep");
    }

    void SeekBehaviour()
    {
        //if (Vector3.Distance(leaderAIController.CharModel.transform.position,
        //    leaderAIController.CharacterLineOfSight.Target.position) > 1)
        //{
            Debug.Log("Ok to find path");
        Transform target = leaderAIController.CharacterLineOfSight.GetLineOfSight();
        Debug.Log("Target position: " + target.position);
        leaderAIController.CharacterPathfinding.FindPath(leaderAIController.CharModel.transform.position,
                target.position);
            leaderAIController.CharModel.TargetSeekNodes = leaderAIController.CharacterPathfinding.finalPath;
            //leaderAIController.CharModel.Run(leaderAIController.CharModel.TargetSeekNodes);
        //}
    }

}
