using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UADE.IA.FSM;

public class LeaderDeathState<T> : FSMState<T>
{
    //Leader _leader;
    //LeaderAnimations _leaderAnimations;

    FSM<T> _fsm;

    public LeaderDeathState(FSM<T> fsm)
    {
        _fsm = fsm;
    }

    public override void Awake()
    {
        Debug.Log("Leader Death State Awake");
    }

    public override void Execute()
    {
        Debug.Log("Leader Death State Execute");
    }

    public override void Sleep()
    {
        Debug.Log("Leader Death State Sleep");
    }
}
