using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class PlayerMovementController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    [SerializeField] private Transform spriteTansform;
    private Transform playerTransform;


    /// Awake is called when the script instance is being loaded.
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerTransform = GetComponent<Transform>();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Movement.performed += PlayerMovement;
    }



    // This is the event pattern using C# events. The user subcribes to different input actions that are assigned through the inspector.
    // In code, the user subscribes to the method in the awake each time the specific input action is invoked "(in this case it's player movement)

    // IF want movement to be smaller or bugger, use multiplier and mulply by player translate
    public void PlayerMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 inputVect = playerInputActions.Player.Movement.ReadValue<Vector2>();
            playerTransform.Translate(inputVect.x, inputVect.y, 0);
            Quaternion charRotation = spriteTansform.rotation;
            if (inputVect.x > 0)
            {
                charRotation = Quaternion.Euler(0f, 0f, -90f);
            }
            else if (inputVect.x < 0)
            {
                charRotation = Quaternion.Euler(0f, 0f, 90f);
            }

            if (inputVect.y > 0)
            {
                charRotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (inputVect.y < 0)
            {
                charRotation = Quaternion.Euler(0f, 0f, 180f);
            }
            spriteTansform.rotation = charRotation;
        }
    }
}
