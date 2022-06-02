using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDmgNode : NodeIA
{
    private float playerdmg;
    private float threshold;

    public PlayerDmgNode(float playerdmg, float threshold)
    {
        this.playerdmg = playerdmg;
        this.threshold = threshold;
    }

    public override NodeState Evaluate()
    {
        return playerdmg >= this.threshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
