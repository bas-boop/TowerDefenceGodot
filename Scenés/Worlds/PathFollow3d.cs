using Godot;
using System;

public partial class PathFollow3d : PathFollow3D
{
	[Export] private float _speed = 10;
	private float _ourProgress;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_ourProgress += 0.01f * _speed;
		
		SetProgress(_ourProgress);
	}
}
