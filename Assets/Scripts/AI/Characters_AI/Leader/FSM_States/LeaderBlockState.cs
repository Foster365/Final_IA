using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UADE.IA.FSM;
using static UnityEngine.GraphicsBuffer;
using System;

public class LeaderBlockState<T> : FSMState<T>
{
    //Leader _leader;
    //LeaderAnimations _leaderAnimations;

    CharacterAIController leaderAIController;

    FSM<T> _fsm;
    T _idleState;

    public LeaderBlockState(CharacterAIController _leaderAIController, FSM<T> fsm, T idleState)
    {
        leaderAIController = _leaderAIController;
        _fsm = fsm;
        _idleState = idleState;
    }

    public override void Awake()
    {
        Debug.Log("Leader Block State Awake");
    }

    public override void Execute()
    {
        Debug.Log("Leader Block State Execute");
    }

    public override void Sleep()
    {
        Debug.Log("Leader Block State Sleep");
    }
}
