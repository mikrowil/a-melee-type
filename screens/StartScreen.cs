using Godot;
using System;

public partial class StartScreen : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void on_quit()
	{
		GetTree().Quit();
	}

	private void _on_start_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://screens/testing_stage.tscn");
	}
}
