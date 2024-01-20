using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public sealed class PlayerObject  : AcObject
{

    protected override void EnterAwake()
    {
        base.EnterAwake();

    }
    

    private void OnEnable()
    {
        
    }

    protected override void RegistObserver()
    {
        base.RegistObserver();
        BattleManager.GetInstance.AddPlayerObserver(this);
    }

    protected override void EnterDie()
    {
        base.EnterDie();

    }
}
