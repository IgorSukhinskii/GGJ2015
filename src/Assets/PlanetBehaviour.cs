using UnityEngine;
using System.Collections;

public class PlanetBehaviour : MonoBehaviour {
    public float orbitRadius;
    public float orbitalSpeed;
    public float selfRotationSpeed;
    public float planetRadius;
    public float orbitalPosition;

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3(0, orbitRadius, 0);
        // посчитать x через радиус орбиты и текущий орбитальный угол, центр вращения -- 0;0

		float rad = orbitalSpeed * Mathf.Deg2Rad;
		Debug.Log(orbitalSpeed + "degrees are equal to " + rad + " radians.");

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
}
