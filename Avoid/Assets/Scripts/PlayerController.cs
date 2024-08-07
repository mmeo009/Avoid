using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity;
    [SerializeField] private Transform playerBody;          // 플레이어
    [SerializeField] private Transform cameraLocation;      // 카메라
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float xRotation = 0f;
    void Start()
    {
        // 커서 지우기
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        PlayerMove();
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

        playerBody.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);
    }
}
