using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeCheckNode : NodeIA
{
    private Observer obs;

    public ModeCheckNode(Observer obs)
    {
        this.obs = obs;
    }

    public override NodeState Evaluate()
    {
        return obs.mode == null ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
