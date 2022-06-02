using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : NodeIA
{
    protected NodeIA node;

    public Inverter(NodeIA node)
    {
        this.node = node;
    }

    public override NodeState Evaluate()
    {
        switch (node.Evaluate())
        {
            case NodeState.RUNNING:
                _nodeState = NodeState.RUNNING;
                break;
            case NodeState.FAILURE:
                _nodeState = NodeState.SUCCESS;
                break;
            case NodeState.SUCCESS:
                _nodeState = NodeState.FAILURE;
                break;
            default:
                break;
        }
        return _nodeState;
    }
}
