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

    //��ü ������ ����
    public void AddObserver(AcObject observer)
    {
        acObserver.Add(observer);
        int key = acObserver.Count -1;
        observer.gameObject.GetComponent<AcObject>().GetObjectKey(key);
        //Debug.Log("Observer Key [" + key + "]");
    }

    //�÷��̾� ������ ����
    public void AddPlayerObserver(AcObject observer)
    {
        playerObserver.Add(observer);
        int key = playerObserver.Count -1;
        observer.gameObject.GetComponent<AcObject>().GetTypeObjectKey(key);
        //Debug.Log("Player Observer Key [" + key + "]");
    }

    //���ʹ� ������ ����
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
            //���������� �ٸ� �������� ���� ������

        }
    }

    //��ü ������ �Լ� ȣ��
    public void OnNotifyObserver()
    {
        foreach(AcObject aObserver in acObserver)
        {
            Debug.Log("��ü ������ �Լ� ȣ��");
            aObserver.CallObservser();
        }
    }

    //�÷��̾� ������ �Լ� ȣ��
    public void OnNotifyPlayerObserver()
    {
        foreach (AcObject pObserver in playerObserver)
        {
            Debug.Log("�÷��̾� ������ �Լ� ȣ��");
        }
    }

    //���ʹ� ������ �Լ� ȣ��
    public void OnNotifyEnemyObserver()
    {
        foreach (AcObject eObserver in enemyObserver)
        {
            Debug.Log("���ʹ� ������ �Լ� ȣ��");
        }
    }

    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            //������ ��ü ȣ��
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