using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState : MonoBehaviour {
	public bool pressed { get; set; }

	public void Pressed() {
		pressed = !pressed;
	}

	public string SaveMe() {
		SerializableButton serializableButton = new SerializableButton {
			pressed = this.pressed
		};

		return JsonUtility.ToJson( serializableButton );
	}

	public void LoadMe( string json ) {
		SerializableButton serializableButton = JsonUtility.FromJson<SerializableButton>( json );
		pressed = serializableButton.pressed;
	}
}

public class SerializableButton
{
    public bool pressed;
}