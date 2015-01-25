using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Score").GetComponent<Text>().text =
            "Score: " + GameObject.Find("Lamplighter").GetComponent<PlayerBehaviourScript>().score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
