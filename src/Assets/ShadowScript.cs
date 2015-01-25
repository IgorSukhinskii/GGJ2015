using UnityEngine;
using System.Collections;

public class ShadowScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var planet = GetComponentInParent<PlanetBehaviour>();
        var difficulty = GameObject.Find("Lamplighter").GetComponent<PlayerBehaviourScript>().difficulty;
        var rotationSpeed = (planet.orbitalSpeed - planet.selfRotationSpeed) * Time.deltaTime * difficulty;
        this.transform.Rotate(0, 0, rotationSpeed);
	}
}
