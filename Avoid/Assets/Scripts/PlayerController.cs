using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZoneType
{
    NONE,
    DOOR,
    EXIT,
    BED
}

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity;
    public Rigidbody rigidbody;
    private ZoneType myZone;

    private static event Action<ZoneType> OnPlayerEnterInteractionZone;
    private static event Action OnPlayerExitInteractionZone;

    [SerializeField] private GameObject zoneInteractionHelper;
    [SerializeField] private Transform playerBody;          // 플레이어
    [SerializeField] private Transform cameraLocation;      // 카메라
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float xRotation = 0f;
    private void OnEnable()
    {
        OnPlayerEnterInteractionZone += EnterInteractionZone;
        OnPlayerExitInteractionZone += ExitInteractionZone;
    }
    private void OnDisable()
    {
        OnPlayerEnterInteractionZone -= EnterInteractionZone;
        OnPlayerExitInteractionZone -= ExitInteractionZone;
    }
    void Start()
    {
        // 커서 지우기
        Cursor.lockState = CursorLockMode.Locked;

        if(!TryGetComponent<Rigidbody>(out rigidbody))
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }
    }
    void Update()
    {
        PlayerMove();

        if(Input.GetKeyDown(KeyCode.E) && myZone != ZoneType.NONE)
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

    private void EnterInteractionZone(ZoneType zoneType)
    {
        zoneInteractionHelper.SetActive(true);

        if (zoneType == ZoneType.DOOR)
        {
            myZone = ZoneType.DOOR;
        }
        else if(zoneType == ZoneType.BED)
        {
            myZone = ZoneType.BED;
        }
        else if (zoneType == ZoneType.EXIT)
        {
            myZone = ZoneType.EXIT;
        }
        else
        {
            zoneInteractionHelper.SetActive(false);
            return;
        }    
    }
    private void ExitInteractionZone()
    {
        zoneInteractionHelper.SetActive(false);
        myZone = ZoneType.NONE;
    }
}
