using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNode : NodeIA
{
    private string mode;
    private int num;
    private AttackController attacks;

    public AttackNode(string mode, int num, AttackController attacks)
    {
        this.mode = mode;
        this.num = num;
        this.attacks = attacks;
    }

    public override NodeState Evaluate()
    {
        switch(this.mode)
        {
            case "hard":
                switch(this.num)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
                break;
            case "normal":
                switch (this.num)
                {
                    case 1:
                        //HM1A();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;   
                }
                break;
            case "izi":
                switch (this.num)
                {
                    case 1:
                        //HM1A();
                        break;
                }
                break;
        }
        return NodeState.SUCCESS;
    }

    //private void HM1A();
}
