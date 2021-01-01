using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AU_PlayerController : MonoBehaviour
{
    [SerializeField] bool hasControl;
    public static AU_PlayerController localPlayer; // singletone
    
    // Components
    Rigidbody myRB;
    Transform myAvatar;
    Animator myAnim;
    // Player movement
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;
    // Player color
    static Color myColor;
    SpriteRenderer myAvatarSprite;


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
        if (hasControl)
        {
            localPlayer = this;
        }

        myRB = GetComponent<Rigidbody>();
        myAvatar = transform.GetChild(0);
        myAnim = GetComponent<Animator>();
        myAvatarSprite = myAvatar.GetComponent<SpriteRenderer>();

        if (myColor == Color.clear)
        {
            myColor = Color.white;
        }
        myAvatarSprite.color = myColor;
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
                                // cobines the x and the y into 1 value
        myAnim.SetFloat("Speed", movementInput.magnitude); 
    }

    
    private void FixedUpdate()
    {
        // handle the actual movment of the player
        myRB.velocity = movementInput * movementSpeed;
    }

    public void SetColor(Color newColor)
    {
        myColor = newColor;
        if (myAvatarSprite != null)
        {
            print("color index = " + myColor);
            myAvatarSprite.color = myColor;
        }
    }
}
