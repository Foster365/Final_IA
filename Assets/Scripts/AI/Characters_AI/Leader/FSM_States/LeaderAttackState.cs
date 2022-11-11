using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UADE.IA.FSM;

public class LeaderAttackState<T> : FSMState<T>
{
    //Leader _leader;
    //LeaderAnimations _leaderAnimations;

    CharacterAIController leaderAIController;

    FSM<T> _fsm;
    T _seekState;
    T _damageState;

    public LeaderAttackState(CharacterAIController _leaderAIController, FSM<T> fsm,
    T seekState, T damageState)
    {

        leaderAIController = _leaderAIController;
;

        _fsm = fsm;
        _seekState = seekState;
        _damageState = damageState;
    }

    public override void Awake()
    {
        Debug.Log("Leader Attack State Awake");
    }

    public override void Execute()
    {
        Debug.Log("Leader Attack State Execute");
    }

    public override void Sleep()
    {
        Debug.Log("Leader Attack State Sleep");
    }
}
