using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardGOAPTest : GAgent
{
    // Start is called before the first frame update
    bool goToAlarm = false;
    void Start()
    {
        base.Start(); //GAgent script start
        SubGoal s1 = new SubGoal("Patrolled", 1, false);
        goals.Add(s1, 3);

        beliefs.ModifyState("shouldPatrol", 0);

        SubGoal s2 = new SubGoal("RaiseAlarm", 1, false);
        goals.Add(s2, 10);

        SubGoal s3 = new SubGoal("SmokeBreak", 1, false);
        goals.Add(s3, 4);

        SubGoal s4 = new SubGoal("CheckedTreasure", 1, false);
        goals.Add(s4, 6);

        Invoke("Smoke", Random.Range(10, 30));

        Invoke("CheckTreasure", Random.Range(70, 100));


    }
    void Update()
    {
        if (foundPlayer && goToAlarm == false)
        {
            FoundPlayer();
            goToAlarm = true;

        }
    }
    void FoundPlayer()
    {

        beliefs.ModifyState("foundPlayer", 0); //found player injected into belief system, can now be used as a precondition
    }

    void Smoke()
    {
        beliefs.ModifyState("needSmoke", 0);
        Invoke("Smoke", Random.Range(40, 100));
    }
    void CheckTreasure()
    {
        beliefs.ModifyState("checkTreasure", 0);
        Invoke("CheckTreasure", Random.Range(20, 60));
    }


}
