using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleManager : Singleton<BattleManager>
{
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    #region About_Observer

    List<AcObject> acObserver = new List<AcObject>();
    List<AcObject> playerObserver = new List<AcObject>();
    List<AcObject> enemyObserver = new List<AcObject>();

    //전체 옵저버 저장
    public void AddObserver(AcObject observer)
    {
        acObserver.Add(observer);
        int key = acObserver.Count -1;
        observer.gameObject.GetComponent<AcObject>().GetObjectKey(key);
        //Debug.Log("Observer Key [" + key + "]");
    }

    //플레이어 옵저버 저장
    public void AddPlayerObserver(AcObject observer)
    {
        playerObserver.Add(observer);
        int key = playerObserver.Count -1;
        observer.gameObject.GetComponent<AcObject>().GetTypeObjectKey(key);
        //Debug.Log("Player Observer Key [" + key + "]");
    }

    //에너미 옵저버 저장
    public void AddEnemyObserver(AcObject observer)
    {
        enemyObserver.Add(observer);
        int key = enemyObserver.Count -1;
        observer.gameObject.GetComponent<AcObject>().GetTypeObjectKey(key);
    }


    public void ObserverToObserver(int sendKey, int reciveKey)
    {
        var sendObserver = acObserver[sendKey];
        var reciveObserver = acObserver[reciveKey];

        if(sendObserver && reciveObserver)
        {
            //옵저버에서 다른 옵저버로 정보 보내기

        }
    }

    //전체 옵저버 함수 호출
    public void OnNotifyObserver()
    {
        foreach(AcObject aObserver in acObserver)
        {
            Debug.Log("전체 옵저버 함수 호출");
            aObserver.CallObservser();
        }
    }

    //플레이어 옵저버 함수 호출
    public void OnNotifyPlayerObserver()
    {
        foreach (AcObject pObserver in playerObserver)
        {
            Debug.Log("플레이어 옵저버 함수 호출");
        }
    }

    //에너미 옵저버 함수 호출
    public void OnNotifyEnemyObserver()
    {
        foreach (AcObject eObserver in enemyObserver)
        {
            Debug.Log("에너미 옵저버 함수 호출");
        }
    }

    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            //옵저버 전체 호출
            OnNotifyObserver();
        }
    }

    public void ClearObserver()
    {
        acObserver.Clear();
        playerObserver.Clear();
        enemyObserver.Clear();
    }




}//end class