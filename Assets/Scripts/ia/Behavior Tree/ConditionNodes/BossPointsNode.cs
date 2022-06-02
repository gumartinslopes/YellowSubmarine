using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPointsNode : NodeIA
{
    private float bp;
    private float threshold;

    public BossPointsNode(float bp, float threshold)
    {
        this.bp = bp;
        this.threshold = threshold;
    }

    public override NodeState Evaluate()
    {
        return bp >= this.threshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
