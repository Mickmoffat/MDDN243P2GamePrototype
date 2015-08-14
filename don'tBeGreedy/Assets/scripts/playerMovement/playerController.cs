using UnityEngine;
using System.Collections;
/*** Don't Be Greedy Prototype Alpha 1B player controller Script >:) [5.5] ***/
public class PlayerController : MonoBehaviour {
    /**** VARABLES ****/

    /** PUBLIC **/
    public float rotateSpeed = 2.0f; //rotate
    public float forwardSpeed = 2.0f; //forward
    private CharacterController playerController;

    /** PRIVATE **/
	// Use this for initialization
	void Start () {
	
        /* getComponet*/
        playerController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        /* Check to see if grounded JUMP*/

        if (Input.GetKey(KeyCode.Space) && playerController.isGrounded) {
            playerController.Move(Vector3.up);//force up

        }
        /* rotate 
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        //TEMP FLOAT */
        Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
        float speed = forwardSpeed * Input.GetAxis("Vertical"); //pos or neg number apply forward
        playerController.SimpleMove(speed * forward); 

        /* rotate v2*/

        /* Move FB
        if (Input.GetButtonDown("Vertical")) {
 
            //FORWARD
            if (Input.GetAxis("Vertical") > 0) {

                Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
                float speed = forwardSpeed * Input.GetAxis("Vertical"); //pos or neg number apply forward
                playerController.SimpleMove(speed * forward); 

            }

            //BACKWARD
            else {
                Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
                float speed = forwardSpeed * Input.GetAxis("Vertical"); //pos or neg number apply forward
                playerController.SimpleMove(speed * forward); 

            
            }

        } */

        /* ROTATE LR */
        if (Input.GetButtonDown("Horizontal")) { 

            //RIGHT
            if (Input.GetAxis("Horizontal") > 0) {

                playerController.transform.Rotate(0, 90, 0);
                Debug.Log("right [A]");
            }

            //LEFT
            else {
                playerController.transform.Rotate(0, -90, 0);
                Debug.Log("left [D]");
            }
        
        }
	}
}
