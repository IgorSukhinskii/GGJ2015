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
        var headPosition3 = onPlanet.planet.transform.position + diff;
        var headPosition = new Vector2(headPosition3.x, headPosition3.y);
        var hit = Physics2D.Raycast(headPosition, Vector2.zero - headPosition,
            Vector2.Distance(headPosition, Vector2.zero) + 0.01f);
        if (hit.collider != null)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
	}
}
