using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UADE.IA.FSM;

public class LeaderDamageState<T> : FSMState<T>
{
    //Leader _leader;
    //LeaderAnimations _leaderAnimations;

    CharacterAIController leaderAIController;

    FSM<T> _fsm;
    T _attackState;
    T _idleState;
    T _deathState;

    public LeaderDamageState(CharacterAIController _leaderAIController, FSM<T> fsm,
    T attackState, T idleState, T deathState)
    {

        leaderAIController = _leaderAIController;

        _fsm = fsm;
        _attackState = attackState;
        _idleState = idleState;
        _deathState = deathState;
    }

    public override void Awake()
    {
        Debug.Log("Leader Damage State Awake");
    }

    public override void Execute()
    {
        Debug.Log("Leader Damage State Execute");
    }

    public override void Sleep()
    {
        Debug.Log("Leader Damage State Sleep");
    }
}
