using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public int mvDist = 2;

    Transform t;
    Rigidbody r;

    public GameObject c;

	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
        r = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, t.TransformDirection(Vector3.forward) * mvDist);
        //movment
        if (Input.GetKeyDown(KeyCode.W)) {
            
            RaycastHit hit;

            /*
            print(Physics.Raycast(transform.position, t.TransformDirection(Vector3.forward), out hit, mvDist));
            
            if (!Physics.Raycast(transform.position, t.TransformDirection(Vector3.forward), out hit, mvDist))
            {
                t.position += t.forward * mvDist;
               // Vector3 v = t.position + t.TransformDirection(Vector3.forward);
                //r.MovePosition(v);
            }
             */

            if (CanMove.main.yes)
            {
                t.position += t.forward * mvDist;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            t.position += t.TransformDirection(Vector3.left) * mvDist /2.5f; // 
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            t.position += t.forward * -mvDist; // 

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            t.position += t.TransformDirection(Vector3.right) * mvDist /2.5f; // 
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            t.Rotate(0, -90, 0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            t.Rotate(0, 90, 0);
        }
	
	}
}
