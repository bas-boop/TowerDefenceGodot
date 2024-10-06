using Godot;

namespace GeenZinInUnityCSharp.Scripts.Framework
{
	public partial class Waypoints : Node3D
	{
		[Export] private Node3D[] _waypoints;
		
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}

		public Node3D GetWaypoint(int index) => _waypoints[index];
		
		public int GetSize() => _waypoints.Length;
	}
}