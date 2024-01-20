using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AcObject
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
        BattleManager.GetInstance.AddEnemyObserver(this);
    }

    protected override void EnterDie()
    {
        base.EnterDie();

    }

}