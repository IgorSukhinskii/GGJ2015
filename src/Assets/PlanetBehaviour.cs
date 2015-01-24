using UnityEngine;
using System.Collections;

public class PlanetBehaviour : MonoBehaviour {
    public float orbitRadius;
    public float orbitalSpeed;
    public float selfRotationSpeed;
    public float planetRadius;
    public float orbitalPosition;
    public float selfRotationPosition;
	// Use this for initialization
	void Start () {
        this.transform.Rotate(0, 0, selfRotationPosition);
        this.transform.position = new Vector3(0, 0, 0);
        // посчитать x через радиус орбиты и текущий орбитальный угол, центр вращения -- 0;0

	}
	
	// Update is called once per frame
	void Update () {
        float selfRotationCurrentSpeed = selfRotationSpeed * Time.deltaTime;
        selfRotationPosition += selfRotationCurrentSpeed;
	}
}
