using System;
using System.Collections.Generic;
using CrashoutSimulator.Scripts.Abstracts;
using Godot;

namespace CrashoutSimulator.Scripts;

public abstract class StateMachine<TA, TE>
    where TE : Enum
    where TA : Node3D
{
    
    private readonly Dictionary<TE, AState<TA, TE>> _states = new Dictionary<TE, AState<TA, TE>>();
    
    private AState<TA, TE> _currentState = null;
    
    public void Update(float delta)
    {
        _currentState.Update(delta);
    }

    public void ChangeState(AState<TA, TE> callingState, TE stateKey)
    {
        if (callingState != _currentState)
        {
            GD.PrintErr("State change called by non active state: " + callingState.GetType());
            return;
        }

        _currentState?.Exit();
        _currentState = callingState;
        _currentState.Enter();
    }
    
    public bool AddState(TE stateKey, AState<TA, TE> state)
    {
        return _states.TryAdd(stateKey, state);
    }
    
    public bool RemoveState(TE stateKey)
    {
        return _states.Remove(stateKey);
    }
}