using UnityEngine;
using System.Collections;

public class PlanetBehaviour : MonoBehaviour {
    public float orbitRadius;
    public float orbitalSpeed;
    public float selfRotationSpeed;
    public float planetRadius;
    public float orbitalPosition;
    public int hitPoints;
    public int maxHitPoints;
    public LampBehaviourScript lamp;
	public SpriteRenderer halo;
	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3(0, orbitRadius, 0);
	}


	
	// Update is called once per frame
	void Update () {
        var difficulty = GameObject.Find("Lamplighter").GetComponent<PlayerBehaviourScript>().difficulty;
        float selfRotationCurrentSpeed = selfRotationSpeed * Time.deltaTime * difficulty;
		this.transform.Rotate(0, 0, selfRotationCurrentSpeed);

		float orbitalCurrentSpeed = orbitalSpeed * Time.deltaTime * difficulty;
		float newX =  Mathf.Cos (orbitalCurrentSpeed * Mathf.Deg2Rad)* this.transform.position.x
					- Mathf.Sin (orbitalCurrentSpeed * Mathf.Deg2Rad)* this.transform.position.y;

		float newY = Mathf.Sin (orbitalCurrentSpeed * Mathf.Deg2Rad)* this.transform.position.x
					+ Mathf.Cos (orbitalCurrentSpeed * Mathf.Deg2Rad)* this.transform.position.y;
		
		this.transform.position = new Vector3(newX, newY, 0);

	}

	public float getPercentageOfCurrentHP() {
		return (float) hitPoints / (float) maxHitPoints;
	}

    public void Damage(int damage)
    {

		this.halo.color = new Color (1, 0.3f, 0, 1);
        if (hitPoints <= 0)
        {
            return;
        }

        this.hitPoints -= damage;
        if (this.hitPoints > this.maxHitPoints) this.hitPoints = this.maxHitPoints;
        if (damage > 0)
        {
            GameObject.Find("Lamplighter").GetComponent<PlayerBehaviourScript>().breakStreak();
        }
        if (this.hitPoints <= 0)
        {
            Debug.Log("Planet dieded =(");
            var player = GameObject.Find("Lamplighter").GetComponent<PlayerBehaviourScript>();
            player.planetsLeft--;
            Debug.Log(player.planetsLeft);
            if (player.planetsLeft == 0)
            {
                Debug.Log("Gaym ova");
                GameObject.Find("HighScores").GetComponent<HighScoresScript>().score = player.score;
                Application.LoadLevel(2);
            }
        }



		float currentPercentage = getPercentageOfCurrentHP ();
		//Debug.Log(currentPercentage);
		GetComponent<SpriteRenderer> ().color = new Color(currentPercentage,currentPercentage,currentPercentage,1);
	}

    void OnMouseDown()
    {
        this.lamp.Switch();
    }
}
