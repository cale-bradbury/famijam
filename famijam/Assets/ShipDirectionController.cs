using UnityEngine;
using System.Collections;

public class ShipDirectionController : MonoBehaviour {

    public new Transform camera;

    bool down = false;
    float offset = 0;
    void OnMouseDown()
    {
        down = true;
        offset = camera.transform.localEulerAngles.y - transform.parent.localEulerAngles.y ;
    }

    void OnMouseUp()
    {
        down = false;
    }

    void Update()
    {
        if (!down)
            return;
        transform.parent.localRotation = Quaternion.AngleAxis(camera.transform.localEulerAngles.y - offset, Vector3.up);
    }
}
