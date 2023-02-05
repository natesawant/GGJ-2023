using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : ActivatableInterface
{
    public GameObject opened, closed;
    public override void Activate()
    {
        opened.SetActive(true);
        closed.SetActive(false);
    }

    public override void Deactivate()
    {
        opened.SetActive(false);
        closed.SetActive(true);
    }
}
