using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float Sensitivity;
    public float Smoothing;

    private Vector2 mouseLook;
    private Vector2 smoothV;

    private GameObject player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = transform.parent.gameObject;
        mouseLook.x = (180);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        Vector2 mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDirection.x *= Sensitivity * Smoothing;
        mouseDirection.y *= Sensitivity * Smoothing;

        smoothV.x = Mathf.Lerp(smoothV.x, mouseDirection.x, 1f / Smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDirection.y, 1f / Smoothing);

        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.rotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
