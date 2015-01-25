using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 

public class PlayerBehaviourScript : MonoBehaviour {
    List<GameObject> planets;

	public int score;
	public int streak;
    public float difficulty;
    public int planetsLeft;

	public void increaseScore(){
		score += 10*(int)Mathf.Pow(2, streak);
        streak++;
	}

	public void breakStreak(){
		streak = 0;
	}

    void UpdateDifficulty(float dt)
    {
        if (difficulty < 2)
            difficulty += dt / 100.0f;
    }


	// Use this for initialization
	void Start () {
        planets = new List<GameObject>();
        foreach (Transform child in GameObject.Find("Planets").transform)
        {
            planets.Add(child.gameObject);
        }
        planetsLeft = planets.Count;
        DontDestroyOnLoad(this);
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

            var lamp = GetComponent<LamplighterBehaviourScript>().planet.lamp;
            if (lamp.isLighted)
            {
                GetComponent<Animator>().SetTrigger("Blow");
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Light");
            }
            lamp.Switch();
            if (lamp.isLighted == lamp.onDarkSide)
            {
                this.increaseScore();
            }
            Debug.Log(planets.Count);
        }
        UpdateDifficulty(Time.deltaTime);
	}
}
