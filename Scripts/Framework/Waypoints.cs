using Godot;

namespace GeenZinInUnityCSharp.Scripts.Framework
{
	public partial class Waypoints : Node3D
	{
		// The Transform is a part of Node3D, Transform3D is a struct and not an object unlike Unity
		[Export] private Node3D[] _waypoints;
		
		public override void _Ready()
		{
			
		}
		
		public override void _Process(double delta)
		{
			
		}
		
		public Node3D GetWaypoint(int index) => _waypoints[index];
		
		public int GetSize() => _waypoints.Length;
	}
}