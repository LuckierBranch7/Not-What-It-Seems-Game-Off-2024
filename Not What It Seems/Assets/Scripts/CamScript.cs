using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// CamScript is responsible for handling the camera movement based on mouse input.
public class CamScript : MonoBehaviour
{
    /// Sensitivity of the mouse input.
    public float sensitivity;

    /// The orientation transform that will be rotated along with the camera.
    public Transform orientation;

    /// The current rotation around the x-axis.
    float xRot;

    /// The current rotation around the y-axis.
    float yRot;

    /// Initializes the script by locking the cursor and making it invisible.
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// Updates the camera rotation based on mouse input.
    void Update() {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRot, 0f);
    }
}
