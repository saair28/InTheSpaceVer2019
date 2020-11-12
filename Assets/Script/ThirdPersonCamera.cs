using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    /*
    public float mouseSensitivity = 10;
    public Transform target;
    public float dstFromTarget = 2;
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float yaw;
    float pitch;
    */
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    public Transform t_camera;

    private RaycastHit hit;
    private Vector3 camera_offset;

    void Start()
    {

        camera_offset = t_camera.localPosition;
        
    }

    void Update()
    {
        CursorControl();
        CamControl();

        if (Physics.Linecast(transform.position, transform.position + transform.localRotation*camera_offset, out hit))
        {
            t_camera.localPosition = new Vector3(0, 0, -Vector3.Distance(transform.position, hit.point));
        }
        else
        {
            t_camera.localPosition = Vector3.Lerp(t_camera.localPosition,camera_offset,Time.deltaTime);
        }
    }

    void LateUpdate()
    {
        //CursorControl();
        //CamControl();
        /*
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);                                                                                         
        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * dstFromTarget;
        */

        
    }
    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }

        
    }

    void CursorControl()
    {
        if (Input.GetKey(KeyCode.X)) 
        {
            Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
