using Godot;

namespace CrashoutSimulator.Scripts;

public partial class PlayerCharacter3D : CharacterBody3D
{
    public override void _Ready()
    {
        GD.Print("Ready");
    }
}