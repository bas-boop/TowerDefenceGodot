using Godot;

namespace GeenZinInUnityCSharp.Scripts.Player
{
	public partial class CharacterBody2d : CharacterBody2D
	{
		private const float SPEED = 300.0f;
		private const float JUMP_VELOCITY = -400.0f;

		public override void _PhysicsProcess(double delta)
		{
			Vector2 velocity = Velocity;

			if (!IsOnFloor())
				velocity += GetGravity() * (float)delta;
			
			if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
				velocity.Y = JUMP_VELOCITY;
			
			Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		
			velocity.X = direction != Vector2.Zero
				? direction.X * SPEED
				: Mathf.MoveToward(Velocity.X, 0, SPEED);
		
			Velocity = velocity;
			MoveAndSlide();
		}
	}
}
