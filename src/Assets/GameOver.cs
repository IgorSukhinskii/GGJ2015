using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Score").GetComponent<Text>().text =
            "Score: " + GameObject.Find("HighScores").GetComponent<HighScoresScript>().score;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Application.LoadLevel(1);
        }
	}
}
