using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    
    private PlayerInputAction playerInputAction;
    private InputAction movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake(){
        playerInputAction = new PlayerInputAction();
    }

    private void OnEnable(){
        movement = playerInputAction.Player.Movement;
        movement.Enable();

    }

    private void OnDisable(){
        movement.Disable();
    }

    private void FixedUpdate(){
        Debug.Log("Movement is:" + movement.ReadValue<Vector2>());
        rb.MovePosition(rb.position + movement.ReadValue<Vector2>() * moveSpeed);
    }
}
