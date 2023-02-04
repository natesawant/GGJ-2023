using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base ability class for all other abilities.
public class Ability : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;
    public float resource;

    public virtual void Activate() {}
}
