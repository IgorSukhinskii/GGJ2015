using UnityEngine;
using System.Collections;

public class LampBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var onPlanet = GetComponent<LamplighterBehaviourScript>();
        var diff = onPlanet.planet.transform.rotation *
            (new Vector3(0, 1, 0) * (onPlanet.planet.planetRadius + onPlanet.height));
        var headPosition = onPlanet.planet.transform.position + diff;
        // проверить, видно ли звезду (0, 0) из headPosition
	}
}
