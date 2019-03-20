using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Instantiator
{
    override public Vector3 GetPositionForFireBall()
    {
        Vector3 position;
        if (this.transform.localScale.y > 0)
            position = new Vector2(this.transform.position.x - 0.6f, instantiationPointDown.position.y);
        else
            position = new Vector2(this.transform.position.x - 0.6f, instantiationPointUp.position.y);
        return position;
    }
}
