using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTreasure : GAction
{
    
    public override bool PrePerform()
    {
        print("getting Treasure");
        return true;
    }
    public override bool PostPerform()
    {
        print("Treasure Checked");
        beliefs.RemoveState("checkTreasure");
        return true;
    }
    

}
