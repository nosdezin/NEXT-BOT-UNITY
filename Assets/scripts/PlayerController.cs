using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float PlayerSpeed = 20f;
    [SerializeField]private float myGravity = -10f;
    [SerializeField]private float expPlusVelo = 0.1f;
    private CharacterController myCC;
    private Vector3 inputVector;
    private Vector3 movementVector;
    private PlayerInput pi;
    private Vector3 velocity;
    private float expVelo = 1f;
    public int PowerCount;

    void Awake() 
    {
        myCC = GetComponent<CharacterController>();
        pi = GetComponent<PlayerInput>();
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        PowerCount = 0;
    }

    void Update() 
    {
        GetInput();
        MovePlayer(); 
        cameraLook();

        if(inputVector.x != 0 || inputVector.z != 0)
        {
            if(expVelo <= 2.5f)
            {
                expVelo += expPlusVelo * Time.deltaTime;
            }
        }else{
            expVelo = 1f;
        }
    }

    private void GetInput()
    {
        Vector2 moveInput = pi.actions["Andar"].ReadValue<Vector2>();
        inputVector = new Vector3(moveInput.x,0f,moveInput.y);
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);
        movementVector = (inputVector * PlayerSpeed * expVelo) + (Vector3.up * myGravity);
    }

    private void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime);
    }

    private void cameraLook()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Quaternion target = Quaternion.Euler( Mathf.Clamp(mousePos.y * -1,-60f,60f), mousePos.x, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);
        
    }
}
