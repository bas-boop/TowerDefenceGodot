using Godot;

using GeenZinInUnityCSharp.Scripts.Framework;

namespace GeenZinInUnityCSharp.Scripts.NPC
{
    /// <summary>
    /// An unused enemy movement class, that did not work?
    /// The reason why is not found and this code was also tested in Unity and worked fine.
    /// After going to the first object and updating the target it did not work for the second target.
    /// </summary>
    public partial class EnemyMovement : RigidBody3D
    {
        [Export] private Waypoints _waypoints;
        
        [Export] private float _speed = 1;
        [Export] private float _waypointMargin = 0.2f;

        private int _currentWaypoint;
        private Vector3 _nextPositionTarget;
        
        public override void _Ready()
        {
            if (_waypoints.GetSize() > 0)
                UpdateCurrentTargetPosition();
        }

        public override void _Process(double delta)
        {
            // move to target position
            LinearVelocity = _nextPositionTarget * _speed;
            
            // check if object is at target
            if (_nextPositionTarget.DistanceTo(Transform.Origin) <= _waypointMargin)
            {
                GD.Print("Is at target");
                
                if (_currentWaypoint == _waypoints.GetSize())
                {
                    GD.Print("End");
                    QueueFree(); // delete game object
                    return;
                }
                
                // update to new target
                _currentWaypoint++;
                UpdateCurrentTargetPosition();
            }
        }
        
        private void UpdateCurrentTargetPosition()
        {
            // get new position form this objects current position
            _nextPositionTarget = _waypoints.GetWaypoint(_currentWaypoint).Transform.Origin - Transform.Origin;
            _nextPositionTarget.Y = 0;
            GD.Print(_nextPositionTarget);
        }
    }
}
