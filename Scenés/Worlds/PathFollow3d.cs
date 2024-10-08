using Godot;

namespace GeenZinInUnityCSharp.Scenés.Worlds
{
	public partial class PathFollow3d : PathFollow3D
	{
		[Export] private float _speed = 1;
		private float _ourProgress;

		public override void _Ready()
		{

		}

		public override void _Process(double delta)
		{
			_ourProgress += 0.01f * _speed;

			SetProgress(_ourProgress);
		}
	}
}