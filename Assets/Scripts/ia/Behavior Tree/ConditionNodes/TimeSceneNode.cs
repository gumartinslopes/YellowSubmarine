using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSceneNode : NodeIA
{
    private float time;
    private float threshold;

    public TimeSceneNode(float time, float threshold)
    {
        this.time = time;
        this.threshold = threshold;
    }

    public override NodeState Evaluate()
    {
        return time >= 0 ? NodeState.SUCCESS : NodeState.FAILURE;

        //return time >= this.threshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
