using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

    public Transform direction;
    public float speed = 1;
    public float drift = .01f;
    Vector3 targetDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        targetDirection = Vector3.Lerp(targetDirection, direction.position - direction.parent.position, drift);
        transform.position +=  targetDirection * speed * Time.deltaTime;
	}
}
