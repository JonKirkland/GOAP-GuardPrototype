using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBreak : GAction
{
    
    public override bool PrePerform()
    {
        print("started smoking");
        return true;
    }
    public override bool PostPerform()
    {
        print("done smoking");
        beliefs.RemoveState("needSmoke");
        return true;
    }
    

}
