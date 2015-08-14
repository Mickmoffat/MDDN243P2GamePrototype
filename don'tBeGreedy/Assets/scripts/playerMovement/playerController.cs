using UnityEngine;
using System.Collections;
/*** Don't Be Greedy Prototype Alpha 1B player controller Script >:) [5.5] ***/
public class PlayerController : MonoBehaviour
{
    /**** VARABLES ****/

    /** PUBLIC **/
    public float rotateSpeed = 2.0f; //rotate
    public float forwardSpeed = 10.0f; //forward
    public float moveTime = 2f; //movetime
    public bool moveYes = false; //move yes or no
    public float moveForward = 150.0f; //move forward
    public float moveBackwards = -100.0f; //moveBackwards

    /** PRIVATE **/
    private CharacterController playerController;
    // Use this for initialization
    void Start()
    {

        /* getComponet*/
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Check to see if grounded JUMP*/

        if (Input.GetKey(KeyCode.Space) && playerController.isGrounded)
        {
            playerController.Move(Vector3.up);//force up

        }
        /* rotate 
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        //TEMP FLOAT 
        Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
        float speed = forwardSpeed * Input.GetAxis("Vertical"); //pos or neg number apply forward
        playerController.SimpleMove(speed * forward); */


        /** rotate V3 
        if (Input.GetButton("Vertical"))
        {
            //FORWARD
            if (Input.GetAxis("Vertical") > 0 && !moveYes)
            {
                moveTime -= Time.deltaTime; //sets max time for movement

                Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
                float speed = forwardSpeed + Input.GetAxis("Vertical"); //pos or neg number apply forward
                playerController.SimpleMove(speed * forward);

                if (moveTime < 0)
                {
                    moveYes = true;

                }

            }

            //BACKWARD
            else
            {
                moveTime = Mathf.Min(moveTime + Time.deltaTime, 2f);
                if (moveTime > 1) {
                    moveYes = false;
                }
                
                moveTime -= Time.deltaTime;
                Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
                float speed = forwardSpeed * Input.GetAxis("Vertical"); //pos or neg number apply forward
                playerController.SimpleMove(speed * forward);


            }
        
        }**/

        /*transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0); 
        //TEMP FLOAT 
        Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
        float speed = forwardSpeed * Input.GetAxis("Vertical"); //pos or neg number apply forward
        playerController.SimpleMove(speed * forward); */


        /* rotate v2*/

        /* Move FB WORKS */
        if (Input.GetButtonDown("Vertical"))
        {

            //BACKWARD
            if (Input.GetAxis("Vertical") > 0)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
                float speed = forwardSpeed - Input.GetAxis("Vertical"); //pos or neg number apply forward
                playerController.SimpleMove(moveBackwards * forward);
                Debug.Log("back [S]");
            }

            //FORWARD
            else
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
                float speed = forwardSpeed + Input.GetAxis("Vertical"); //pos or neg number apply forward
                playerController.SimpleMove(moveForward * forward); //this sets distance travel
                Debug.Log("forward [W]");
            }

        }

        /* CODE FROM
         http://answers.unity3d.com/questions/611550/how-to-make-a-shift-button-that-stops-after-a-cert.html */

        /* ROTATE LR */
        if (Input.GetButtonDown("leftRight"))
        {

            //RIGHT
            if (Input.GetAxis("leftRight") > 0)
            {

                playerController.transform.Rotate(0, 90, 0);
                Debug.Log("+90 [A]");
            }

            //LEFT
            else {
                playerController.transform.Rotate(0, -90, 0);
                Debug.Log("-90 [D]");
            }

            /** MOVE LEFT RIGHT 2 
            //BACKWARD
            if (Input.GetAxis("Horizontal") > 0) {
                Vector3 forward = transform.TransformDirection(Vector3.left);// looking for player is facing 
                float speed = forwardSpeed - Input.GetAxis("Horizontal"); //pos or neg number apply forward
                playerController.SimpleMove(moveBackwards * forward);
                Debug.Log("Left [A]");
            }

            //FORWARD
            else
            {
                Vector3 forward = transform.TransformDirection(Vector3.left);// looking for player is facing 
                float speed = forwardSpeed + Input.GetAxis("Horizontal"); //pos or neg number apply forward
                playerController.SimpleMove(moveForward * forward); //this sets distance travel
                Debug.Log("Right [D]");
            } */

            /**** IDK CANT GET SIDE TO SIDE RAGE ****/
            if (Input.GetButtonDown("A"))
            {

                //BACKWARD
                if (Input.GetAxis("Horizontal") > 0)
                {
                    Vector3 forward = transform.TransformDirection(Vector3.left);// looking for player is facing 
                    float speed = forwardSpeed - Input.GetAxis("Horizontal"); //pos or neg number apply forward
                    playerController.SimpleMove(moveBackwards * forward);
                    Debug.Log("back [S]");
                }

                //FORWARD
                else
                {
                    Vector3 forward = transform.TransformDirection(Vector3.right);// looking for player is facing 
                    float speed = forwardSpeed + Input.GetAxis("Vertical"); //pos or neg number apply forward
                    playerController.SimpleMove(moveForward * forward); //this sets distance travel
                    Debug.Log("forward [W]");
                }

            }
                

            
            
            /** Move Left Right 
            if (Input.GetButtonDown("Horizontal"))
            {

                //FORWARD
                if (Input.GetAxis("Horizontal") > 0)
                {
                    Vector3 forward = transform.TransformDirection(Vector3.left);// looking for player is facing 
                    float speed = forwardSpeed - Input.GetAxis("Horizontal"); //pos or neg number apply forward
                    playerController.SimpleMove(moveBackwards * forward);




                }

                //BACKWARD
                else
                {

                    Vector3 forward = transform.TransformDirection(Vector3.right);// looking for player is facing 
                    float speed = forwardSpeed + Input.GetAxis("Horizontal"); //pos or neg number apply forward
                    playerController.SimpleMove(moveForward * forward); //this sets distance travel
                }

            } **/


        }
    }
}
