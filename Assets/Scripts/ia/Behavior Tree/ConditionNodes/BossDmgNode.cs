using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDmgNode : NodeIA
{
    private float bossDmg;
    private float threshold;

    public BossDmgNode(float bossDmg, float threshold)
    {
        this.bossDmg = bossDmg;
        this.threshold = threshold;
    }

    public override NodeState Evaluate()
    {
        return bossDmg >= 0 ? NodeState.SUCCESS: NodeState.SUCCESS;
        //return bossDmg >= this.threshold ? NodeState.FAILURE : NodeState.SUCCESS;
    }
}
