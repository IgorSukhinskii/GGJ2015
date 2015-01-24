using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // move out
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //move in
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<LamplighterBehaviourScript>().planet.lamp.Switch();
        }
	}
}
