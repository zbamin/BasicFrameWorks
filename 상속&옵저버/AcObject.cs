using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

abstract public class AcObject : MonoBehaviour
{


    public void ResetObserver()
    {

    }

    //사망 시
    protected virtual void EnterDie() 
    {
        Debug.Log("이 객체가 사망하였습니다 : " + this.gameObject.name);
    }
    

    //옵저버 저장
    protected virtual void RegistObserver() => BattleManager.GetInstance.AddObserver(this);


    //초기화
    protected virtual void EnterAwake() 
    {
        RegistObserver();
    }

    private void Awake() => EnterAwake();
  

    //전체 옵저버 키 
    public void GetObjectKey(int key) => observerKey = key;
    
    //옵저버 키 반환
    public int ReturnObserverKey() { return observerKey; }

    //모든 옵저버 호출
    public void CallObservser() 
    {
        CalledObserver();
    }

    protected void CalledObserver()
    {

    }

}//end class
