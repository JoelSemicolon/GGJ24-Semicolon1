using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject eyePositionAnchor;
    Rigidbody rigidbodyController;
    Vector3 lookAngle = new Vector3(0f, 0f, 0f);
    float lookSpeed = 2f;
    float moveSpeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rigidbodyController = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lookAngle.x -= Input.GetAxisRaw("Mouse Y") * lookSpeed;
        lookAngle.y += Input.GetAxisRaw("Mouse X") * lookSpeed;
        lookAngle.x = Mathf.Clamp(lookAngle.x, -90f, 90f);
        Vector3 adjustedLookAngle = lookAngle;
        adjustedLookAngle.x = 0;
        transform.rotation = Quaternion.Euler(adjustedLookAngle);
        Camera.main.transform.rotation = Quaternion.Euler(lookAngle);
        Camera.main.transform.position = eyePositionAnchor.transform.position;

        //movement
        if (Input.GetKey(KeyCode.W))
        {
            rigidbodyController.MovePosition(rigidbodyController.position + transform.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbodyController.MovePosition(rigidbodyController.position - transform.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbodyController.MovePosition(rigidbodyController.position - transform.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbodyController.MovePosition(rigidbodyController.position + transform.right * moveSpeed * Time.deltaTime);
        }
    }
}
