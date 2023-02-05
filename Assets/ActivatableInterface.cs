using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivatableInterface : MonoBehaviour
{
    abstract public void Activate();
    abstract public void Deactivate();
}
