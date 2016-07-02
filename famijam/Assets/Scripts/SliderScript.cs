using UnityEngine;
using System.Collections;

public class SliderScript : MonoBehaviour {

    public CCReflectFloat output;
    public Vector2 minMax = Vector2.up;
    [Range(0,1)]
    public float startValue = 0;
    public float smoothing = .1f;
    public Transform minPosition;
    public Transform maxPosition;
    public Camera screenCamera;

    bool down = false;
    float v = 0;
    float t = 0;

	// Use this for initialization
	void Start () {
        if (screenCamera == null)
            screenCamera = FindObjectOfType<Camera>();
        t = v = startValue;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 p0 = screenCamera.WorldToScreenPoint(minPosition.position);
        Vector3 p1 = screenCamera.WorldToScreenPoint(maxPosition.position);
        if (down)
        {
            Vector2 p = Input.mousePosition.xy();

            Vector2 a2p = new Vector2(p.x - p0.x, p.y - p0.y);
            Vector2 a2b = new Vector2(p1.x - p0.x, p1.y - p0.y);

            t = Vector2.Dot(a2p, a2b) / Vector2.SqrMagnitude(a2b);
        }
        v = Mathf.Lerp(v, t, smoothing);
        transform.position = screenCamera.ScreenToWorldPoint(Vector3.Lerp(p0,p1,v));
        output.SetValue(Mathf.Lerp(minMax.x, minMax.y, v));
    }

    void OnMouseDown()
    {
        down = true;
    }

    void OnMouseUp()
    {
        down = false;
    }

}
