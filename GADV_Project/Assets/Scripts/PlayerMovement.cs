using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // SerializeField to edit speed directly from Unity.
    // Use [SerializeField] private, instead of public to ensure that only this script can access this variable.
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim; 
    private bool grounded; // Helps to check if player is on or off the ground
    
    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        // Grab references for Rigidbody 2D and Animator from GameObject
        // Use GetComponent to access Rigidbody 2D.
        // GetComponent will check the Player Gameobject for the Rigidbody 2D component.
        // The Rigidbody 2D component will be stored inside the body variable.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Detect when the player presses left/right and move the body in the relevant direction, using the Update method.
    // Update is called every frame, if the MonoBehaviour is enabled.
    private void Update() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Left/Right Movements
        // Use body.velocity to directly change the player's movement speed and direction.
        // Use Vector2 to assign the movement speed in the X and Y axes, because this is a 2D game.
        // Input.GetAxis is a value defined by Unity, which changes the sprite's direction based on which key the player presses.
        // This minimises the number of if-else statements required.
        // body.velocity.y ensures that the Y axis remains unchanged. Nothing happens when W, S, and arrow keys are pressed.
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);


        // Ensure that the sprite flips left/right, when changing directions, by changing the scale on the X axis
        // Flip Right
        // Check if the horizontal input is greater than 0.01, indicating that the player is moving right
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one; // Change the scale of the player to 1 on all axes when the player is facing right

        // Flip Left
        // Check if the horizontal input is smaller than -0.01, indicating that the player is moving left
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);


        // Player Jump
        // Use if Input.GetKey to check for space press, and grounded, to check if the player is on the ground.
        // Input.GetKey can only have 2 values: True when key is pressed, and False when it is not.
        // KeyCode is an enumeration that contains all buttons.
        // Use KeyCode.Space to check if Space was pressed.
        if(Input.GetKey(KeyCode.Space) && grounded)
            // Define what happens when the Space key is pressed.
            Jump();

        
        // Set Animator parameters
        // horizontalInput != 0 is a logical check. 
        // If A/D or arrow keys are not pressed, horizontalInput = 0, (horizontalInput != 0) = False, Running = False -> Idle animation.
        // If A/D or arrow keys are pressed, (horizontalInput != 0) = True, Running = True -> Running animation.
        anim.SetBool("Running", horizontalInput != 0); 

        anim.SetBool("Grounded", grounded);
    }

    // Optimise Jumping code
    private void Jump()
    {
        // body.velocity.x will ensure that the current velocity on the X axis remains unchanged when the Space key is pressed.
        // Applying speed on the Y axis will allow the player to jump when the Space key is pressed.
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        anim.SetTrigger("Jump");
        grounded = false; // Player will no longer be grounded when they jump
    }

    // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check the object with which the player is colliding with, in this case, it is the platform.
        if(collision.gameObject.tag == "Platform")
            grounded = true;

    }

    public bool canAttack()
    {
        // Check if player is on the ground, if this condition is not met, the method will return false and the player cannot attack
        return grounded; 
    }
}
