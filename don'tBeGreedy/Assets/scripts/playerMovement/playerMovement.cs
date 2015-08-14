using UnityEngine;
using System.Collections;
/*** Don't Be Greedy Prototype Alpha 1B player movement Script >:) [5.5] ***/

public class playerMovement : MonoBehaviour
{
    /**** VARABLES ****/

    /** PUBLIC **/
    /* PlayerMovement*/
   public float moveRate  = 2.0f; //player movement speed
   public float moveRateSprint = 2.0f; //player sprint rate
   public float moveRateLR = 2.5f; //player move rate LR
   public float moveRateB = 1.5f; //player move rate Backwards
   public float jumpRate = 0.5f; //player jump height

    /** PRIVATE **/


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {

        //MOVMENT INPUTS
        //WASD only moves player on press not hold
        

        // Forward [W]
        if (Input.GetKeyDown(KeyCode.W)) {

            transform.Translate((Vector3.forward)* moveRate);
            Debug.Log("Forward Key [W]");
        }

        // Left [A]
        if (Input.GetKeyDown(KeyCode.A)) {

            transform.Translate((Vector3.left) * moveRate / moveRateLR); //side movement / 2.5
            Debug.Log("Left Key [A]");
        }
        // Back [S]

        if (Input.GetKeyDown(KeyCode.S)) {

            transform.Translate((Vector3.back)* moveRate / moveRateB); // back movement
            Debug.Log("Back Key [S]");
        }

        // Right [D]
        if (Input.GetKeyDown(KeyCode.D)) {

            transform.Translate((Vector3.right) * moveRate / moveRateLR); //side movement / 2.5
            Debug.Log("Right Key [D]");
        }

        /** ROTATE 90 **/
        // -90 [Q]
        if (Input.GetKeyDown(KeyCode.Q)) {

            transform.Rotate(0,-90 ,0);
            //transform.Translate(Vector3.left);
            Debug.Log("Rotate -90 Key [Q]");
        }
        
       
        // +90 [E]
        if (Input.GetKeyDown(KeyCode.E)) {
            transform.Rotate(0,90,0);
            Debug.Log("Rotate +90 Key [E]");
        }

        /** JUMP **/
        // jump Up [Space]
        if (Input.GetKeyDown(KeyCode.Space)){
            transform.Translate((Vector3.up) * jumpRate);
            Debug.Log("Jump Key [Space]");
        }

        // fall down [Left Control]
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            transform.Translate((Vector3.down) * jumpRate);
            Debug.Log("Jump Key [CTRL]");
        }

        /** SPRINT **/
        // sprint [Left Shift]
        if (Input.GetKey(KeyCode.LeftShift)) {
            moveRate = moveRate * moveRateSprint; //forward [W]
            moveRate = moveRateLR * moveRateSprint; //Left [A]
            moveRate = moveRateB * moveRateSprint; //back [S]
            moveRate = moveRateLR * moveRateSprint; //right [D]
            Debug.Log("Sprint Key [Shift]");
        }

        /* SPRINT REST MOVE RATE */
        /* if shift key not pressed reset values */
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            moveRate = moveRate + 0f; //forward [W]
            moveRate = moveRateLR +0f; //Left [A]
            moveRate = moveRateB +0f; //back [S]
            moveRate = moveRateLR +0f; //right [D]
            Debug.Log("Sprint False");
        
        }


    }
}
