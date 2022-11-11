using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UADE.IA.FSM;
using System;

public class LeaderIdleState<T> : FSMState<T>
{
    //Leader _leader;
    //LeaderAnimations _leaderAnimations;

     CharacterAIController leaderAIController;

    float idleMaxTimer, idleTimer;

    FSM<T> _fsm;
    T patrolState;
    T attackState;
    T blockState;
    T damageState;

    public LeaderIdleState(CharacterAIController _leaderAIController, float _idleMaxTimer,
        FSM<T> fsm, T _patrolState, T _attackState, T _blockState, T _damageState)
    {
        leaderAIController = _leaderAIController;
        idleMaxTimer = _idleMaxTimer;

        _fsm = fsm;
        patrolState = _patrolState;
        attackState = _attackState;
        blockState = _blockState;
        damageState = _damageState;
    }

    public override void Awake()
    {
        Debug.Log("Leader Idle State Awake");
        idleTimer = 0;
    }

    public override void Execute()
    {
        Debug.Log("Leader Idle State Execute");
        idleTimer += Time.deltaTime;
        leaderAIController.CharModel.ReadyToMove = false;
        //Debug.Log("TIMER: " + idleTimer);
        Transform target = leaderAIController.CharacterLineOfSight.GetLineOfSight();
        if (idleTimer >= idleMaxTimer)
        {
            _fsm.Transition(patrolState);
        }
        //else _fsm.Transition(seekState); //En realidad sí va el seeek, hay que volver a setearlo en el constructor y el controller

        //try
        //{

        //    leaderAIController.CharacterLineOfSight.GetLineOfSight();

        //    if (leaderAIController.CharacterLineOfSight != null)
        //        if (Vector3.Distance(leaderAIController.CharacterModel.Target.position, leaderAIController.CharacterModel.PathfindingLastPosition) > 1)
        //        {
        //            leaderAIController.CharacterModel.PathfindingLastPosition = leaderAIController.CharacterModel.Target.position;
        //            leaderAIController.CharacterModel.CharacterPathfinding.FindPath(leaderAIController.transform.position,
        //                leaderAIController.CharacterModel.Target.position);
        //        }
        //}
        //catch (Exception err)
        //{
        //    Debug.LogException(err);
        //}

    }

    public override void Sleep()
    {
        Debug.Log("Leader Idle State Sleep");
    }
}
