using UnityEngine;
using System.Collections;

public class LamplighterBehaviourScript : MonoBehaviour {
    public PlanetBehaviour planet;
    public float height;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var diff = this.planet.transform.rotation *
            (new Vector3(0, 1, 0) * (this.planet.planetRadius + height/2));
        this.transform.position = this.planet.transform.position + diff;
        this.transform.rotation = this.planet.transform.rotation;
	}
}
