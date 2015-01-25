using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
 

public class PlayerBehaviourScript : MonoBehaviour {
    List<GameObject> planets;

	public int score;
	public int streak;
    public float difficulty;
    public int planetsLeft;
    public bool paused = false;

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
	}
	
	// Update is called once per frame
	void Update () {
        var currentPlanet = GetComponent<LamplighterBehaviourScript>().planet;
        var index = planets.FindIndex(0, o => o.Equals(currentPlanet.gameObject));
        if (Input.GetKeyUp(KeyCode.LeftArrow) && index <= (planets.Count - 1) && !paused)
        {
            index--;
            if (index < 0) index = planets.Count - 1;
            GetComponent<LamplighterBehaviourScript>().planet = planets[index].GetComponent<PlanetBehaviour>();
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && index >= 0 && !paused)
        {
            index++;
            if (index > (planets.Count - 1))
            {
                index = 0;
            }
            GetComponent<LamplighterBehaviourScript>().planet = planets[index].GetComponent<PlanetBehaviour>();
        }
        else if (Input.GetKeyUp(KeyCode.Space) && !paused)
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
                GetComponent<LamplighterBehaviourScript>().planet.halo.color = new Color(1, 0.3f, 0, 0);
                this.increaseScore();
                GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + score;
            }
            Debug.Log(planets.Count);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            Application.Quit();
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (paused)
            {
                paused = false;
                Time.timeScale = 1;
                GameObject.Find("Help").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.0f);
            }
            else
            {
                paused = true;
                Time.timeScale = 0;
                GameObject.Find("Help").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
            }
        }
        UpdateDifficulty(Time.deltaTime);
	}
}
