using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ActivatableConsoleLog : ActivatableInterface
{
    public override void Activate()
    {
        Debug.Log("ACTIVATED");
    }

    public override void Deactivate()
    {
        Debug.Log("DEACTIVATED");
    }
}
