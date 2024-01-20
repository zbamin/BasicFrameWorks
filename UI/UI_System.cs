using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_System : MonoBehaviour
{
    protected virtual void PushUI()
    {
        UIManager.Instance.InsertStack(this);
    }

}