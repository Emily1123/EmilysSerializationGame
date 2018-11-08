using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVolume : MonoBehaviour
{
	public void OnTriggerEnter( Collider col )
    {
		Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
	}

	public void OnTriggerExit( Collider col )
    {
		Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
	}
}
