using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity;
    public Rigidbody rigidbody;

    [SerializeField] private Transform playerBody;          // �÷��̾�
    [SerializeField] private Transform cameraLocation;      // ī�޶�
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float xRotation = 0f;
    void Start()
    {
        // Ŀ�� �����
        Cursor.lockState = CursorLockMode.Locked;

        if(!TryGetComponent<Rigidbody>(out rigidbody))
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }
    }
    void Update()
    {
        PlayerMove();

        if(Input.GetKeyDown(KeyCode.E))
        {
            InteractionWithItem();
        }
    }

    private void PlayerMove()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraLocation.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = playerBody.forward * vertical + playerBody.right * horizontal;

        // playerBody.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);

        rigidbody.velocity = moveDir.normalized * moveSpeed + new Vector3(0, rigidbody.velocity.y, 0);
    }

    private void PlayerJump()
    {

    }

    private void InteractionWithItem()
    {

    }
}
