using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 

public class PlayerBehaviourScript : MonoBehaviour {
    List<GameObject> planets;

	public int score;
	public int streak;

	public void increaseScore(){
		if (streak == 0) {
						score += 100;
						++streak;
				}
		else
			score += (int)Mathf.Pow(20, streak++);
	}

	public void breakStreak(){
		streak = 0;
	}


	// Use this for initialization
	void Start () {
        planets = new List<GameObject>();
        foreach (Transform child in GameObject.Find("Planets").transform)
        {
            planets.Add(child.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        var currentPlanet = GetComponent<LamplighterBehaviourScript>().planet;
        var index = planets.FindIndex(0, o => o.Equals(currentPlanet.gameObject));
        if (Input.GetKeyUp(KeyCode.LeftArrow) && index <= (planets.Count - 1))
        {
            index--;
            if (index < 0) index = planets.Count - 1;
            GetComponent<LamplighterBehaviourScript>().planet = planets[index].GetComponent<PlanetBehaviour>();
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && index >= 0)
        {
            index++;
            if (index > (planets.Count - 1))
            {
                index = 0;
            }
            GetComponent<LamplighterBehaviourScript>().planet = planets[index].GetComponent<PlanetBehaviour>();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<LamplighterBehaviourScript>().planet.lamp.Switch();
            Debug.Log(planets.Count);
        }
	}
}
