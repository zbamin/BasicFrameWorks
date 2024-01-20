using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletShooter : MonoBehaviour
{
    [SerializeField]
    [Header("�Ѿ�")]
    GameObject bulletObject;

    [SerializeField]
    [Header("�Ѿ� �߻� ����")]
    private float bulletTime;

    [SerializeField]
    [Header("�Ѿ� �߻� �ӵ�")]
    private float bulletSpeed;

    [SerializeField]
    [Header("�Ѿ� ��ȯ �ð�")]
    private float returnTime;

    private GameObject shooter; //�� 
    float rotX;
    private GameObject playerObject;    //�÷��̾�
    private int facingDir = 1;  //�ٶ󺸴� ���� (1 = ������, -1 = ����)

    Camera cam; //���콺 ��ġ �������� ���� ī�޶�

    //Ǯ��
    Queue<GameObject> bullets = new Queue<GameObject>();

    #region Ǯ��

    void SetPooling()
    {
        for (int i = 0; i < 15; i++)
        {
            bullets.Enqueue((CreateBullet(bulletObject)));
        }
    }
    GameObject CreateBullet(GameObject obj)
    {
        var bullet = Instantiate(obj);
        SetObjectEnQueue(ref bullet);

        return bullet;
    }
    void SetObjectEnQueue(ref GameObject obj)
    {
        obj.transform.SetParent(this.transform);
        obj.SetActive(false);
    }
    void SetObjectDeQueue(ref GameObject obj)
    {
        obj.transform.SetParent(null);
        obj.SetActive(true);
    }
    IEnumerator ObjectDequeue(Queue<GameObject> bulletList) //�Ѿ� ȣ�� �� �߻�
    {
        if(bulletList.Count < 1) 
            bullets.Enqueue((CreateBullet(bulletObject)));

        var bullet = bulletList.Dequeue();
        SetObjectDeQueue(ref bullet);
        bullet.transform.rotation = Quaternion.Euler(GetRot());
        bullet.transform.position = this.transform.position;

        yield return new WaitForSeconds(3f);
        bulletList.Enqueue(bullet);
        SetObjectEnQueue(ref bullet);
    }


    #endregion

    #region ���� 
    private void Awake()
    {
        cam = Camera.main;
        playerObject = GameObject.Find("Player");
        shooter = this.transform.parent.gameObject;
        SetPooling();
    }

    private void OnEnable()
    {
        StartCoroutine(Controller());
        StartCoroutine(UpdateCor());
    }
    #endregion

    IEnumerator Controller()    //�Ѿ� �߻� �ڷ�ƾ
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                StartCoroutine(ObjectDequeue(bullets));
            }
            yield return new WaitForSeconds(bulletTime);
        }
    }

    IEnumerator UpdateCor()
    {
        while (true)
        {
            ShooterRot();
            yield return null;
        }
    }

    Vector3 GetRot()  //�Ѿ� �߻� ���� 
    {
        //���콺 �������� �߻�
        var mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Input.mousePosition.z));
        var vec = mousePosition - playerObject.transform.position;
        var dir = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;

        Vector3 rot = new Vector3(0, 0, dir);
        return rot;
    }

    private void ShooterRot()   //�� ����
    {
        Vector3 rot = GetRot();

        if (rot.z >= 90 || rot.z <= -90)
        {this.GetComponent<SpriteRenderer>().flipY = true;}
        else
        { this.GetComponent<SpriteRenderer>().flipY = false; }

        shooter.transform.rotation = Quaternion.Euler(rot);
    }

}
