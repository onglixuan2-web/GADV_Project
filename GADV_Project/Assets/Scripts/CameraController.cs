using UnityEngine;

public class CameraController : MonoBehaviour
{    
    // Follow Player
    // Reference to player's Transform, in order to ensure the Player Object will be followed
    [SerializeField] private Transform player; 
    // Make the camera look forward in the direction that the player is heading towards
    [SerializeField] private float aheadDistance; // How far the camera is able to look forward
    [SerializeField] private float cameraSpeed; // Camera movement speed
    private float lookAhead;

    private void Update()
    {
        // Follow Player
        // Create a new Vector3 for the camera's position
        // Use the player's X position for the camera's X axis and keep the Y and Z axes unchanged
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        // use the Lerp() method to gradually change the value of lookAhead from an initial value to a final value.
        // The initial value is the value of lookAhead itself.
        // Multiply the aheadDistance by player.localScale.x to get the final value.
        // This ensures that when the player is moving, the camera will take the player's position on the X axis and add the lookAhead value.
        // This will make the camera look slightly forward in that direction
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
