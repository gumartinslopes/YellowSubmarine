using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpNode : NodeIA
{
    private float playerhp;
    private float threshold;

    public PlayerHpNode(float playerhp, float threshold)
    {
        this.playerhp = playerhp;
        this.threshold = threshold;
    }

    public override NodeState Evaluate()
    {
        return playerhp >= 0 ? NodeState.SUCCESS : NodeState.FAILURE;

        //return playerhp >= threshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
