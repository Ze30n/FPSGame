using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("XuanTien/MouseMovement")]
public class MouseMovement : MonoBehaviour
{
    public float mouseSensivity = 500f;
    public float xRotation;
    public float yRotation;
    public float topClamp = -90f;
    public float bottomClamp = 90f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") *mouseSensivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
