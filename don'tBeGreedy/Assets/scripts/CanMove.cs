using UnityEngine;
using System.Collections;

public class CanMove : MonoBehaviour {

    public static CanMove main;

    public bool yes = true;

	// Use this for initialization
	void Start () {
        main = this;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        yes = true;
	}

    void OnTriggerStay()
    {
        yes = false;
    }

}
