using Godot;

using GeenZinInUnityCSharp.Scripts.Framework;

namespace GeenZinInUnityCSharp.Scripts.NPC
{
    public partial class EnemyMovement : RigidBody3D
    {
        [Export] private Waypoints _waypoints;
        
        [Export] private float _speed = 1;
        [Export] private float _waypointMargin = 0.2f;

        private int _currentWaypoint;
        private Vector3 _nextPositionTarget;
        
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            if (_waypoints.GetSize() > 0)
                UpdateCurrentTargetPosition();
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
            LinearVelocity = _nextPositionTarget * _speed;
            
            if (_nextPositionTarget.DistanceTo(Transform.Origin) <= _waypointMargin)
            {
                GD.Print("Close");
                
                if (_currentWaypoint == _waypoints.GetSize())
                {
                    GD.Print("End");
                    QueueFree();
                    return;
                }
                
                _currentWaypoint++;
                UpdateCurrentTargetPosition();
            }
        }
        
        private void UpdateCurrentTargetPosition()
        {
            _nextPositionTarget = _waypoints.GetWaypoint(_currentWaypoint).Transform.Origin - Transform.Origin;
            _nextPositionTarget.Y = 0;
            GD.Print(_nextPositionTarget);
        }
    }
}
