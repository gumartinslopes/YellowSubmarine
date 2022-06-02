using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : NodeIA
{
    protected List<NodeIA> nodes = new List<NodeIA>();

    public Selector(List<NodeIA> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        foreach (var node in nodes)
        {
            switch(node.Evaluate())
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    return _nodeState;
                case NodeState.FAILURE:
                    break;
                case NodeState.SUCCESS:
                    _nodeState = NodeState.SUCCESS;
                    return _nodeState;
                default:
                    break;
            }
        }

        _nodeState = NodeState.FAILURE;
        return _nodeState;
    }
}
