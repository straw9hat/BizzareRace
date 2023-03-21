using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.Utility;

public class HeadBob : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 0.3f;

    public GameObject player;
    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = player.GetComponent<PlayerInput>();
    }


     private void Update()
     {
        rotationX += playerInput.actions["Look"].ReadValue<Vector2>().y * -1 * sensitivity;
        rotationY += playerInput.actions["Look"].ReadValue<Vector2>().x * sensitivity;
        transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);
    }

}
