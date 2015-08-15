using UnityEngine;
using UnityEngine.UI; //calls UI
using System.Collections;

/*** Don't Be Greedy Prototype Alpha 1c player controller Script >:) [5.6] ***/
public class PlayerController : MonoBehaviour
{
    /**** VARABLES ****/

    /*** PUBLIC ***/
    /** MOVMENT **/
    public float rotateSpeed = 2.0f; //rotate
    public float forwardSpeed = 10.0f; //forward
    public float moveTime = 2f; //moveTime
    public bool moveYes = false; //move yes or no

    /* MOVE SPEED */
    public int moveForward = 120; //move forward
    public int moveBackwards = -50; //moveBackwards

    /** SPRINT **/
    public int sprintSpeed = 2; //sprint speed

    /** STEPS TAKEN **/
    //used for food and water decrementation && counting movements
    /* MOVE */
    public int forwardMoveCount; //keypress forward [W]
    public int backwardMoveCount; //keypress backward [S]
    public int leftMoveCount; //keypress left [A]
    public int rightMoveCount; //keypress right [D]

    /* ROTATE */
    public int rotateNeg90Count; //keypress neg 90 [Q]
    public int rotatePos90Count; //keypress pos 90 [E]

    /** DEBUGGING UI **/
    /* MOVE */
    public Text forwardCountText; //var for forward count UI
    public Text backwardCountText; //var for backward count UI

    /* ROTATE */
    public Text rotateLeftCountText; //var for rotate left count UI
    public Text rotateRightCountText; //var for rotate right count UI

    /** Speed **/

    public Text forwardSpeedText;
    public Text backwardSpeedText;
    public Text speedText; 
    /** PRIVATE **/
    private CharacterController playerController;

    // Use this for initialization

    /***** START *****/
    void Start() {

    /** MOVE START VALUES **/
    forwardMoveCount = 0; //keypress forward [W]
    backwardMoveCount = 0; //keypress backward [S]
    leftMoveCount = 0; //keypress left [A]
    rightMoveCount = 0; //keypress right [D]

    /* ROTATE */
    rotateNeg90Count = 0; //keypress neg 90 [Q]
    rotatePos90Count = 0; //keypress pos 90 [E]

    /** DEBUGGING UI **/
    /* MOVE */
    setForwardCountText(); //calls function to display ui text
    setbackwardCountText(); //calls function to display ui text

    /* ROTATE */
    setRotateLeftCountText(); //method for rotate left count UI
    setRotateRightCountText(); //method for rotate right count UI

    /** SPEED */

    setForwardSpeedText(); //method for forwardSpeed UI
    setBackwardSpeedText(); //method for backwardSpeed UI
    
    


    /* PLAYER CONTROLER*/
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame


    void Update() {
        /* Check to see if grounded JUMP*/

        if (Input.GetKey(KeyCode.Space) && playerController.isGrounded)
        {
            playerController.Move(Vector3.up);//force up

        }
       

        /**** MOVEMENT ****/

        /**** SPEC ACTIONS ****/
        /*** SPRINT ***/
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            moveForward = moveForward * sprintSpeed;
            moveBackwards = moveBackwards * sprintSpeed;

            Debug.Log("Sprint True [Shift]");
        }

        /* SPRINT REST MOVE RATE */
        /* if shift key not pressed reset values */
        if (!Input.GetKey(KeyCode.LeftShift)) {
            moveForward = moveForward = 120 ; //forward [W]
            moveBackwards = moveBackwards = -50 ; //back [S]

            Debug.Log("Sprint False");
        } 

        /* Move FB WORKS */
        if (Input.GetButtonDown("Vertical")) {

            //BACKWARD
            if (Input.GetAxis("Vertical") > 0) {

                Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
                float speed = forwardSpeed -= Input.GetAxis("Vertical"); //pos or neg number apply forward
                playerController.SimpleMove(moveBackwards * forward);


                //count && debugging
                backwardMoveCount += 1;
                //display to string
                setbackwardCountText(); //calls function to display ui text

                Debug.Log("backNumb" + moveBackwards.ToString());
                
                Debug.Log("back [S]");
            }

            //FORWARD
            else  {
                Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
                float speed = forwardSpeed += Input.GetAxis("Vertical"); //pos or neg number apply forward
                playerController.SimpleMove(moveForward * forward); //this sets distance travel

                //count && debugging
                forwardMoveCount += 1;

                setForwardCountText(); //calls function to display ui text


                Debug.Log("forwardNumb" + moveForward.ToString());
                Debug.Log("forward [W]");
            }

        }

        /* CODE FROM
         http://answers.unity3d.com/questions/611550/how-to-make-a-shift-button-that-stops-after-a-cert.html */

        /* ROTATE LR */
        if (Input.GetButtonDown("leftRight")) {

            //RIGHT
            if (Input.GetAxis("leftRight") > 0) {

                playerController.transform.Rotate(0, 90, 0);
                //count && debugging
                rotatePos90Count += 1;
                //display to string
                setRotateRightCountText(); //calls function to display ui text//calls function to display ui text

                Debug.Log("+90 [Q]");
            }

            //LEFT
            else {
                playerController.transform.Rotate(0, -90, 0);
                //count && debugging
                rotateNeg90Count += 1;
                //display to string
                setRotateLeftCountText(); //calls function to display ui text

                Debug.Log("-90 [E]");
            }





           /**** LEFT RIGHT USING A AND D STRAFE ****/

            /**** IDK CANT GET SIDE TO SIDE RAGE ***
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

            } */







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

    /**** DEBUGGING UI METHODS ****/
    /** MOVE **/
    /* FORWARD */
    void setForwardCountText() {
        forwardCountText.text = "FC: " + forwardMoveCount.ToString();
    }
    /* BACKWARD */

    void setbackwardCountText() {
        backwardCountText.text = "BC: " + backwardMoveCount.ToString();
    }

    /** ROTATE **/
    /* LEFT */
    void setRotateLeftCountText() {
        rotateLeftCountText.text = "LRot: " + rotateNeg90Count.ToString();
    }
    /* RIGHT */
    void setRotateRightCountText() {
        rotateRightCountText.text = "RRot: " + rotatePos90Count.ToString();
    }

    /** SPEED **/
    /* GEN SPEED */

    /* FORWARD SPEED */
    void setForwardSpeedText() {
        forwardSpeedText.text = "FS: " + moveForward.ToString();
    }
     /* BACKWARD SPEED */

    void setBackwardSpeedText()
    {
        backwardSpeedText.text = "BS: " + moveBackwards.ToString();
    } 

}
