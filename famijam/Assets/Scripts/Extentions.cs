using UnityEngine;

public static class Extentions {

    //places the point on the line between 2 other points
	public static void MoveToLine(this Vector2 p, Vector2 a, Vector2 b)
    {
        Vector2 a2p = new Vector2(p.x - a.x, p.y - a.y);
        Vector2 a2b = new Vector2(b.x - a.x, b.y - a.y);
        
        float t = Vector2.Dot(a2p, a2b) / Vector2.SqrMagnitude(a2b);
        p.x = a.x + a2b.x * t;
        p.y = a.y + a2b.y * t;

    }

    //swizzles
    public static Vector2 xy(this Vector3 a){return new Vector2(a.x, a.y);}

}
