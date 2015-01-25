using UnityEngine;
using System.Collections;

public class ShadowScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var planet = GetComponentInParent<PlanetBehaviour>();
        var rotationSpeed = (planet.orbitalSpeed - planet.selfRotationSpeed) * Time.deltaTime;
        this.transform.Rotate(0, 0, rotationSpeed);
	}
}
