using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UADE.IA.FSM;
using static UnityEngine.GraphicsBuffer;
using System;

public class LeaderPatrolState<T> : FSMState<T>
{
    //Leader _leader;
    //LeaderAnimations _leaderAnimations;

    CharacterAIController leaderAIController;

    Transform target;

    float patrolMaxTimer, patrolTimer;

    FSM<T> fsm;
    T idleState;
    T seekState;

    public LeaderPatrolState(CharacterAIController _leaderAIController, float _patrolMaxTimer, FSM<T> _fsm, T _idleState, T _seekState)
    {
        leaderAIController = _leaderAIController;

        patrolMaxTimer = _patrolMaxTimer;

        patrolTimer = 0;
        fsm = _fsm;

        idleState = _idleState;
        seekState = _seekState;
    }

    public override void Awake()
    {
        Debug.Log("Leader Patrol State Awake");

    }

    public override void Execute()
    {
        Debug.Log("Leader Patrol State Execute");
        patrolTimer += Time.deltaTime;
        Debug.Log("Patrol timer is: " + patrolTimer);
        Debug.Log("Move? " + leaderAIController.CharModel.ReadyToMove);
        Debug.Log("In sight?: " + leaderAIController.CharacterLineOfSight.targetInSight);
        PatrolBehaviour();
        if (patrolTimer <= patrolMaxTimer && leaderAIController.CharacterLineOfSight.targetInSight) fsm.Transition(seekState);
        //else fsm.Transition(idleState);
        //if (leaderAIController.CharacterPathfinding.finalPath != null)
        //{
        //    Debug.Log("Final path nodes count: " + leaderAIController.CharacterPathfinding.finalPath.Count);
        //    leaderAIController.CharacterModel.waypoints = leaderAIController.CharacterPathfinding.finalPath;
        //    Debug.Log("Player waypoints: " + leaderAIController.CharacterModel.waypoints.Count);
        //    //transition to seek. Acá ejecuto esta línea de código.
        //    leaderAIController.CharacterModel.Run();
        //}
    }

    public override void Sleep()
    {
        Debug.Log("Leader Patrol State Sleep");
        patrolTimer = 0;
    }

    void PatrolBehaviour()
    {
        leaderAIController.CharModel.ReadyToMove = true;
        leaderAIController.CharModel.PatrolSimple();
        leaderAIController.CharacterLineOfSight.GetLineOfSight();

    }
}
