using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{

    [SerializeField] private AttackController AttackController;
    [SerializeField] private Submarine submarine;
    public float playerdmg;
    public float bossdmg;
    public float time;
    public float bp;
    private Selector topNode;

    // Start is called before the first frame update
    void Start()
    {
        this.playerdmg = 0;
        this.bossdmg = 0;
        this.time = 0;
        ConstructBehaviorTree();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time % 10 >= 0 && time % 10 <= 1.0) 
        {
            BPCalculation();
            topNode.Evaluate();
        };
    }

    private void BPCalculation ()
    {
        this.bp = (playerdmg - bossdmg + submarine.hp + time);
    }

    public float getPlayerDmg() { return this.playerdmg; }
    public float getBossDmg() { return this.bossdmg; }
    public float getPlayerHP() { return this.submarine.hp; }
    public float getTimeScene() { return this.time; }
    public float getBP() { return this.bp; }


    private void ConstructBehaviorTree()
    {
        //Cria os AttackNodes
        AttackNode HM1AN = new AttackNode("hard", 1, AttackController);
        AttackNode HM2AN = new AttackNode("hard", 2, AttackController);
        AttackNode HM3AN = new AttackNode("hard", 3, AttackController);
        AttackNode HM4AN = new AttackNode("hard", 4, AttackController);
        AttackNode HM5AN = new AttackNode("hard", 5, AttackController);

        AttackNode NM1AN = new AttackNode("normal", 1, AttackController);
        AttackNode NM2AN = new AttackNode("normal", 2, AttackController);
        AttackNode NM3AN = new AttackNode("normal", 3, AttackController);

        AttackNode EM1AN = new AttackNode("izi", 1, AttackController);

        //Cria os conditions nodes

        BossDmgNode bossDmgNode = new BossDmgNode(this.bossdmg, 0);
        BossPointsNode bossPointsNode = new BossPointsNode(this.bp, 0);
        PlayerDmgNode playerDmgNode = new PlayerDmgNode(this.playerdmg, 0);
        PlayerHpNode playerHpNode = new PlayerHpNode(this.submarine.hp, 0);
        TimeSceneNode timeSceneNode = new TimeSceneNode(this.time, 0);


        //buildando a arvore

        //izi tree
        Selector IziMode = new Selector(new List<NodeIA> { EM1AN });

        //normal tree
        Sequence NM3AS = new Sequence(new List<NodeIA> { NM3AN });
        Sequence NM2AS = new Sequence(new List<NodeIA> { NM2AN, new PlayerDmgNode(playerdmg, 0), NM3AS});
        Sequence NM1AS = new Sequence(new List<NodeIA> { NM1AN, new BossDmgNode(bossdmg, 0), NM2AS });
        Sequence NormalMode = new Sequence(new List<NodeIA> { new BossPointsNode(bp, 50), NM1AS });

        //hard tree
        Sequence HM5AS = new Sequence(new List<NodeIA> { HM5AN });
        Sequence HM4AS = new Sequence(new List<NodeIA> {HM4AN, new PlayerDmgNode(playerdmg, 0), HM5AN });
        Sequence HM3AS = new Sequence(new List<NodeIA> { HM3AN, new BossDmgNode(bossdmg, 0), HM4AN });
        Sequence HM2AS = new Sequence(new List<NodeIA> { HM2AN, new PlayerHpNode(submarine.hp, 0), HM3AN });
        Sequence HM1AS = new Sequence(new List<NodeIA> { HM1AN, new TimeSceneNode(time, 0), HM2AN });
        Sequence HardMode = new Sequence(new List<NodeIA> { new BossPointsNode(bp, 100), HM1AS });

        topNode = new Selector(new List<NodeIA> { HardMode, NormalMode, IziMode });

    }
}
