using System;
using UnityEngine;

[Serializable]
public class MouseLook: MonoBehaviour
{
    public Vector2 sensitivity = Vector2.one;
    public Vector2 yMinMax = new Vector2(-80,80);
    public float smoothing = 5f;
    Vector2 t = Vector2.zero;
    Vector2 r = Vector2.zero;


    void Update()
    {
        r.x += Input.GetAxis("Mouse X") * sensitivity.x;
        r.y += Input.GetAxis("Mouse Y") * sensitivity.y;
        r.y = Mathf.Clamp(r.y, yMinMax.x, yMinMax.y);
        t = Vector2.Lerp(t, r, smoothing);
        transform.localRotation = Quaternion.Euler(t.y,t.x,0);
    }


   /* Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

        angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }*/

}
