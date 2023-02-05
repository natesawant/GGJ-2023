using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RootEntangleAbility : Ability
{
    public int waterCost;
    public int entangleRange;
    public override void Activate(GameObject parent)
    {
        IsometricPlayerMovement movement = parent.GetComponent<IsometricPlayerMovement>();

        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();
    
        
    }

}
