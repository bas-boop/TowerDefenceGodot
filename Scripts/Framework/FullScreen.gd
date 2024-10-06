extends Node

@export var shouldBeFullScreen: bool = false

func _ready() -> void:
	if shouldBeFullScreen:
		DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_EXCLUSIVE_FULLSCREEN)
