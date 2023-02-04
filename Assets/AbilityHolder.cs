using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{

    public RootEntangleAbility entangle;
    float cooldownTime;
    float activeTime;
     public KeyCode key;

    enum AbilityState {
        ready, 
        active, 
        cooldown
    }
    AbilityState state = AbilityState.ready;

    // Update is called once per frame
    void Update()
    {

        switch(state)
        {
            case AbilityState.ready: 
                if(Input.GetKeyDown(key)) 
                {
                    entangle.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = entangle.activeTime;
                }
            break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    cooldownTime = entangle.cooldownTime;
                }
            break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
            break;
        }

    }
}
