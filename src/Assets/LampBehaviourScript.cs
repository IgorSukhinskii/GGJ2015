using UnityEngine;
using System.Collections;

public class LampBehaviourScript : MonoBehaviour {
    public bool isLighted;
    private const float damageTickLength = 1;
    private float damageTickTimer = damageTickLength;
    public bool onDarkSide;
	// Use this for initialization
	void Start () {
        GetComponent<LamplighterBehaviourScript>().planet.lamp = this;
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
        onDarkSide = hit.collider == onPlanet.planet.GetComponent<CircleCollider2D>();
        damageTickTimer -= Time.deltaTime;
        if (damageTickTimer < 0)
        {
            damageTickTimer = damageTickLength;
            if (onDarkSide != this.isLighted)
            {
                onPlanet.planet.Damage(10);
            }
        }
        if (this.isLighted)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
	}
    public void Switch()
    {
        this.isLighted = !this.isLighted;
    }
}
