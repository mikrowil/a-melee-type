using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public const float Speed = 300.0f;
    public const float JumpVelocity = -400.0f;
    public int DoubleJumps = 1;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
        AnimatedSprite2D animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        
        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }
        else
        {
            DoubleJumps = 1;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("ui_accept") && (IsOnFloor() || DoubleJumps > 0))
        {
            velocity.Y = JumpVelocity;
            animatedSprite2D.Play("Jump");
            
            if (!IsOnFloor())
            {
                DoubleJumps = DoubleJumps - 1;
            }
        }

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
            if (direction.X > 0)
            {
                animatedSprite2D.FlipH = false;
                animatedSprite2D.Play("Running");
            }
            else if (direction.X < 0)
            {
                animatedSprite2D.FlipH = true;
                animatedSprite2D.Play("Running");
            }
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            animatedSprite2D.Play("new_animation");
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}