using System;
using Godot;

namespace CrashoutSimulator.Scripts.Abstracts;

public abstract class AState<TA, TE>(StateMachine<TA, TE> stateMachine, TA actor)
    where TE : Enum 
    where TA : Node3D
{
    
    private readonly StateMachine<TA, TE> _stateMachine = stateMachine;
    private readonly TA _actor = actor;
    
    public abstract void Enter();
    public abstract void Update(float delta);
    public abstract void Exit();
}