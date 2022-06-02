using System;
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

    void update(){}

    public override NodeState Evaluate()
    {
        
        switch(this.mode)
        {
            case "hard":
                switch(this.num)
                {
                    case 1:
                        attacks.HM1A();
                        WaitForSeconds(5);
                        break;
                    case 2:
                        attacks.HM2A();
                        WaitForSeconds(5);
                        break;
                    case 3:
                        attacks.HM3A();
                        WaitForSeconds(5);
                        break;
                }
                break;
            case "normal":
                switch (this.num)
                {
                    case 1:
                        attacks.NM1A();
                        WaitForSeconds(5);
                        break;
                    case 2:
                        attacks.NM2A();
                        WaitForSeconds(5);
                        break;
                    case 3:
                        attacks.NM3A();
                        WaitForSeconds(5);
                        break;   
                }
                break;
            case "izi":
                switch (this.num)
                {
                    case 1:
                        attacks.EM1A();
                        WaitForSeconds(5);
                        break;
                    case 2:
                        attacks.EM2A();
                        WaitForSeconds(5);
                        break;
                    case 3:
                        attacks.EM3A();
                        WaitForSeconds(5);
                        break;
                }
                break;
        }
        return NodeState.SUCCESS;
    }

    private IEnumerator WaitForSeconds(int v)
    {
        yield return new WaitForSeconds(v);
    }
}
