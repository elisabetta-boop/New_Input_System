using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    Vector2 moveVector;
    public float movementSpeed;
    public CharacterController controller;
    float verticalSpeed;
    public float gravityMultiplier;
    public float jump;

    public void ShootyMcShoot(InputAction.CallbackContext context)
    {
       if (context.performed)
        {
            Debug.Log("PAN!");
        } 
        else if (context.canceled) 
        {
            Debug.Log("bruit de la balle que tombe");
        }
   }
   public void Move(InputAction.CallbackContext context)
   {
       moveVector = context.ReadValue<Vector2>();
   }

   public void Jump(InputAction.CallbackContext context) 
   {
       if (context.performed && controller.isGrounded)
        {
            Debug.Log("Jump");
            verticalSpeed += jump;
        }
   }

   void Update() 
   {
       if (controller.isGrounded && verticalSpeed < 0) 
       {
            verticalSpeed = 0; // la vitesse vertical el peut bouger
       }
       else // pas au sol
       {
           verticalSpeed += Physics.gravity.y * Time.deltaTime * gravityMultiplier; //gravite
       }
        Vector3 movement = new Vector3(moveVector.x, 0, moveVector.y)* movementSpeed;

        //LORP


        // if (movement != new Vector3(0,0,0))
        // {
        //     transform.forward = movement;
        // }
        // if (movement != Vector3.zero)
        // {
        //     transform.forward = movement;
        // }
        if (movement.magnitude >0)
        {
            transform.forward = Vector3.Lerp(transform.forward, movement, 0.02f); //a chaque frame on fait le 10% du chemin => + vite 
        }


 

        movement.y = verticalSpeed;
        controller.Move( movement * Time.deltaTime );
    }
}

