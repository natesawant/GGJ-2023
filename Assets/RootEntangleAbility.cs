using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootEntangleAbility : MonoBehaviour
{
    public new string name;
    public float cooldownTime;
    public float activeTime;
    public float resource;

    public virtual void Activate() {}
}
