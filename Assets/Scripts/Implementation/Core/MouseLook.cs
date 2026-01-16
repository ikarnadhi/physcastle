using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform Playerbody;
    float xRot = 0;
    public GameObject flashlight;
    public GameObject flashonlogo;
    public GameObject flashofflogo;
    bool flashon = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        updateLook();
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (!flashon)
                flashon = true;
            else
                flashon = false;
        }
        if (flashon)
        {
            flashlight.SetActive(true);
            flashonlogo.SetActive(true);
            flashofflogo.SetActive(false);
        }
        else
        {
            flashlight.SetActive(false);
            flashonlogo.SetActive(false);
            flashofflogo.SetActive(true);
        }
    }

    void updateLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        Playerbody.Rotate(Vector3.up * mouseX);
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
    }
}
