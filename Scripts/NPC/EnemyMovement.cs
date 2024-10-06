using Godot;

using GeenZinInUnityCSharp.Scripts.Framework;

namespace GeenZinInUnityCSharp.Scripts.NPC
{
    public partial class EnemyMovement : RigidBody3D
    {
        [Export] private Waypoints _waypoints;
        
        [Export] private float _speed = 1;
        
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            // Vector3 target = _waypoints.GetWaypoint(0).Transform.Origin;
            // target.Y = Transform.Origin.Y;
            // LinearVelocity = target;

            for (int i = 0; i < _waypoints.GetSize(); i++)
            {
                Transform = Transform with { Origin = _waypoints.GetWaypoint(i).Transform.Origin };
                GD.Print($"Updated position: {Transform.Origin}");
            }
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            
        }
    }
}
