using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

abstract public class AcObject : MonoBehaviour
{


    public void ResetObserver()
    {

    }

    //��� ��
    protected virtual void EnterDie() 
    {
        Debug.Log("�� ��ü�� ����Ͽ����ϴ� : " + this.gameObject.name);
    }
    

    //������ ����
    protected virtual void RegistObserver() => BattleManager.GetInstance.AddObserver(this);


    //�ʱ�ȭ
    protected virtual void EnterAwake() 
    {
        RegistObserver();
    }

    private void Awake() => EnterAwake();
  

    //��ü ������ Ű 
    public void GetObjectKey(int key) => observerKey = key;
    
    //������ Ű ��ȯ
    public int ReturnObserverKey() { return observerKey; }

    //��� ������ ȣ��
    public void CallObservser() 
    {
        CalledObserver();
    }

    protected void CalledObserver()
    {

    }

}//end class
