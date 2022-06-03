using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPointsNode : NodeIA
{
    private float bp;
    private float threshold;
    private Observer obs;

    public BossPointsNode(float bp, float threshold, Observer obs)
    {
        this.bp = bp;
        this.threshold = threshold;
        this.obs = obs;
    }

    public override NodeState Evaluate()
    {
        NodeState result = bp >= this.threshold ? NodeState.SUCCESS : NodeState.FAILURE;
        if(result == NodeState.SUCCESS)
        {
            if (this.threshold == 50) obs.mode = "normal";
            else if (this.threshold == 100) obs.mode = "hard";
            else obs.mode = "izi";
        }
        return result;
    }
}
