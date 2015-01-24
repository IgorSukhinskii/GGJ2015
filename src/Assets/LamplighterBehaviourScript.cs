using UnityEngine;
using System.Collections;

public class LamplighterBehaviourScript : MonoBehaviour {
    public PlanetBehaviour planet;
    public float height;
    public float angle;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var rotation = Quaternion.Euler(0, 0, this.planet.transform.rotation.eulerAngles.z + angle);
        var diff = rotation *
            (new Vector3(0, 1, 0) * (this.planet.planetRadius + height/2));
        this.transform.position = this.planet.transform.position + diff;
        this.transform.rotation = rotation;
	}
}
