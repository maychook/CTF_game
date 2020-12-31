using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AU_PlayerController : MonoBehaviour
{
    // Components
    Rigidbody myRB;
    Transform myAvatar;
    // Player movement
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;


    private void OnEnable()
    {
        WASD.Enable();
    }

    private void OnDisable()
    {
        WASD.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAvatar = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = WASD.ReadValue<Vector2>();

        // if movment left the the x value will be -1, if right then 1 if not moving then 0
        if (movementInput.x != 0) 
        {                                 // x will be equal to 1 or -1, y = 1
            myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
        }
    }

    
    private void FixedUpdate()
    {
        // handle the actual movment of the player
        myRB.velocity = movementInput * movementSpeed;
    }
}
