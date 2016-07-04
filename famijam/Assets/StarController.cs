using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {

    public GameObject starPrefab;
    public Transform ship;
    public int count;
    public float range;
    public float height;
    public float removeRange;
    GameObject[] stars;
    int index;
    Vector3 lastPosition = Vector3.zero;


	// Use this for initialization
	void Start () {
        stars = new GameObject[count];
        for(int i = 0; i< count; i++)
        {
            stars[i] = Instantiate<GameObject>(starPrefab);
            stars[i].transform.parent = transform;
            stars[i].transform.position = new Vector3(Random.Range(-range, range), Random.Range(-height, height), Random.Range(-range, range));
        }
	}
    
	// Update is called once per frame
	void Update () {
        index++;
        index %= count;
        if (Vector3.Distance(ship.position, stars[index].transform.position) > removeRange)
        {
            float a = Random.value * Mathf.PI*.5f-Mathf.PI*.25f+Mathf.Atan2(ship.transform.position.z - lastPosition.z, ship.transform.position.x - lastPosition.x);
            stars[index].transform.position = ship.position + new Vector3(Mathf.Cos(a)*range, Random.Range(-height, height),Mathf.Sin(a)*range);
        }
        lastPosition = ship.transform.position;
    }
}
