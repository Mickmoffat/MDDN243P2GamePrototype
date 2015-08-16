using UnityEngine;
using UnityEngine.UI; //calls UI
using System.Collections;

/*** Don't Be Greedy Prototype Alpha 1d player controller Script >:) [6.1] ***/
public class PlayerController : MonoBehaviour
{
    /**** VARABLES ****/

    /*** PUBLIC ***/
    /** MOVMENT **/
    public float rotateSpeed = 2.0f; //rotate
    public float forwardSpeed = 10.0f; //forward
    public float moveTime = 1f; //moveTime [notSureIfDoesAnything]
    public bool moveYes = false; //move yes or no

    /* MOVE SPEED */
    public int moveForward = 120; //move forward
    public int moveBackwards = -50; //moveBackwards
    public int moveStrafeL = 25; //strafe left
    public int moveStrafeR = -25; //strafe right

    /** SPRINT **/
    public int sprintSpeed = 2; //sprint speed

    /** JUMP SPEED **/
    public float jumpSpeed = 100f;
    /* CHECK JUMP */
    public bool jumpYes = false;

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

    /** TIME **/
    public Text moveTimeCountText; //var timer


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
    setMoveTimeCountText(); //method for move time

    
    


    /* PLAYER CONTROLER*/
        playerController = GetComponent<CharacterController>();
    }

    void FixedUpdate() {
        /** JUMP UP **/
        if (Input.GetKeyDown(KeyCode.Space)) {
            //jumpYes = true;
            playerController.Move(Vector3.up);


            Debug.Log("Jump True [Space]");
        }
    }

    // Update is called once per frame


    void Update() {
        /* Check to see if grounded JUMP */


         /* if (Input.GetKey(KeyCode.Space) && jumpYes == true)//playerController.isGrounded)
        {
            playerController.Move(Vector3.up);//force up
            

            Debug.Log("Jump True [Space]");
        } */

            //if (Input.GetKey(KeyCode.Space) && playerController.isGrounded) {
            
            //}



        //if (jumpYes == false) { 

        //    playerController.Move(Vector3.down);

        //    Debug.Log(jumpYes.ToString());
        //}
        /*

        if (Input.GetAxis ("Vertical") > 1 && Input.GetKey(KeyCode.Space)) //&& playerController.isGrounded)
        {
            playerController.Move(Vector3.up);//force up

            Debug.Log("Jump True [Space]");
        }

       else {
       playerController.Move(Vector3.down);
            
       Debug.Log("False True [Space]");
}
       

        /**** MOVEMENT ****/

        /**** SPEC ACTIONS ****/
        /*** JUMP ***/
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerController.Move(Vector3.down);
        }

        /*** SPRINT ***/
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveForward = moveForward * sprintSpeed;
            moveBackwards = moveBackwards * sprintSpeed;
            moveStrafeR = moveStrafeR * sprintSpeed;
            moveStrafeL = moveStrafeL * sprintSpeed;

            Debug.Log("Sprint True [Shift]");
        }

        /* SPRINT REST MOVE RATE */
        /* if shift key not pressed reset values */
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            moveForward = moveForward = 120; //forward [W]
            moveBackwards = moveBackwards = -50; //back [S]
            moveStrafeR = moveStrafeR = 25;
            moveStrafeL = moveStrafeL = -25;

            Debug.Log("Sprint False");
        } 

        /*** STRAFE LR ***/
        if (Input.GetButtonDown("Horizontal"))
        {

            //LEFT
            if (Input.GetAxis("Horizontal") > 0)
            {

                Vector3 forward = transform.TransformDirection(Vector3.left);// looking for player is facing 
                float speed = forwardSpeed += Input.GetAxis("Horizontal"); //pos or neg number apply forward
                playerController.SimpleMove(moveStrafeL * forward); //this sets distance travel


                //count && debugging
                backwardMoveCount += 1;
                //display to string
                setbackwardCountText(); //calls function to display ui text

                //Debug.Log("backNumb" + moveBackwards.ToString());
                Debug.Log("Left [D]");
            }

            //RIGHT
            else
            {
                Vector3 forward = transform.TransformDirection(Vector3.left);// looking for player is facing 
                float speed = forwardSpeed += Input.GetAxis("Horizontal"); //pos or neg number apply forward
                playerController.SimpleMove(moveStrafeR * forward); //this sets distance travel

                //count && debugging
                forwardMoveCount += 1;
                //display to string
                setForwardCountText(); //calls function to display ui text



               // Debug.Log("forwardNumb" + moveForward.ToString());
                Debug.Log("Right [A]");
            }

        }


        /* MOVE FORWARD BACKWARD 
          if (Input.GetButtonDown("Vertical")) {

              //BACKWARD
              if (Input.GetAxis("Vertical") > 0) {

                  Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
                  float speed = forwardSpeed -= Input.GetAxis("Vertical"); //pos or neg number apply forward
                  playerController.SimpleMove(moveBackwards * forward); //this sets distance travel


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
                  //display to string
                  setForwardCountText(); //calls function to display ui text
                


                  Debug.Log("forwardNumb" + moveForward.ToString());
                  Debug.Log("forward [W]");
              }

          } */


        /** MOVE FORWARD BACKWARD 2 TIMER **/
        if (Input.GetButton("Vertical")) 
        {

            /* TIMER IF STATMENT */
            if (moveTime > 1) { 

          

            //BACKWARD
            if (Input.GetAxis("Vertical") > 0)
            {

                Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
                float speed = forwardSpeed -= Input.GetAxis("Vertical"); //pos or neg number apply forward
                playerController.SimpleMove(moveBackwards * forward); //this sets distance travel


                //count && debugging
                backwardMoveCount += 1;
                //display to string
                setbackwardCountText(); //calls function to display ui text
                setMoveTimeCountText();

                //countDown
                moveTime -= 0.5f;

                Debug.Log("backNumb" + moveBackwards.ToString());
                Debug.Log("back [S]");
            }

            //FORWARD
            if (Input.GetAxis("Vertical") < 0)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);// looking for player is facing 
                float speed = forwardSpeed += Input.GetAxis("Vertical"); //pos or neg number apply forward
                playerController.SimpleMove(moveForward * forward); //this sets distance travel

                //count && debugging
                forwardMoveCount += 1;
                //display to string
                setForwardCountText(); //calls function to display ui text
                setMoveTimeCountText();

                //countDown
                moveTime -= 0.5f;


                Debug.Log("forwardNumb" + moveForward.ToString());
                Debug.Log("forward [W]");
            }

                /* reset count down time 
                else {

                    moveTime = moveTime + 2f;
            
                } */

            }


     }
        /* reset count down time */
        if (!Input.GetButton("Vertical")) {
            moveTime = moveTime = 2f;
        }

   

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

        }


    }

    /**** JUMP ****/
    

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
    /* TIME MOVE */
    void setMoveTimeCountText() {
        moveTimeCountText.text = "MT: " + moveTime.ToString();
    }
    /* GEN SPEED */

    /* FORWARD SPEED */


}
