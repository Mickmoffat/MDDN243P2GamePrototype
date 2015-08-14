using UnityEngine;
using System.Collections;
/*** Don't Be Greedy Prototype Alpha 1B player controller Script >:) [5.5] ***/

public class playerController : MonoBehaviour {

    /**** VARABLES ****/

    /** PUBLIC **/
    /* PLAYER MOVE */
    public float moveRate; //player movement speed
    public float moveRateSprint; //player sprint rate
    public float moveRateLR; //player move rate LR
    public float moveRateB; //player move rate Backwards
    public float jumpRate; //player jump height

    /** PRIVATE **/
    private CharacterController playerControler; //sets player control var


	// Use this for initialization
	void Start () {
        
        playerControler = GetComponent<CharacterController>(); // attaches to player
	}
	
	// Update is called once per frame
	void Update () {
        // check to see if player controller is grounded [allow to jump]
        if (Input.GetKeyDown(KeyCode.Space) && playerControler.isGrounded) {

            playerControler.Move(Vector3.up); //force player controller up

            Debug.Log("isGrounded");
        }

        if (!Input.GetKeyDown(KeyCode.Space) && playerControler.isGrounded)
        {

            Debug.Log("notGrounded");
        }

        transform.Rotate(0,Input.GetAxis("") //this part vid 18 [8:08min]

	}
}
