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
	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3(0, orbitRadius, 0);
	}


	
	// Update is called once per frame
	void Update () {
        float selfRotationCurrentSpeed = selfRotationSpeed * Time.deltaTime;
		this.transform.Rotate(0, 0, selfRotationCurrentSpeed);

		float orbitalCurrentSpeed = orbitalSpeed * Time.deltaTime;
		float newX = Mathf.Cos (orbitalCurrentSpeed * Mathf.Deg2Rad)* this.transform.position.x
					- Mathf.Sin (orbitalCurrentSpeed * Mathf.Deg2Rad)* this.transform.position.y;

		float newY = Mathf.Sin (orbitalCurrentSpeed * Mathf.Deg2Rad)* this.transform.position.x
					+ Mathf.Cos (orbitalCurrentSpeed * Mathf.Deg2Rad)* this.transform.position.y;
		
		this.transform.position = new Vector3(newX, newY, 0);

	}
    public void Damage(int damage)
    {
        this.hitPoints -= damage;
        if (this.hitPoints > this.maxHitPoints) this.hitPoints = this.maxHitPoints;
        if (this.hitPoints <= 0) Debug.Log("Planet dieded =(");
    }
    void OnMouseDown()
    {
        this.lamp.isLighted = !this.lamp.isLighted;
    }
}
