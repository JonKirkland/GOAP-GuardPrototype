using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAlarm : GAction
{
    
    public override bool PrePerform()
    {

        return true;
    }
    public override bool PostPerform()
    {
        //code to end game
        return true;
    }
    

}
