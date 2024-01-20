using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletShooter : MonoBehaviour
{
    [SerializeField]
    [Header("총알")]
    GameObject bulletObject;

    [SerializeField]
    [Header("총알 발사 간격")]
    private float bulletTime;

    [SerializeField]
    [Header("총알 발사 속도")]
    private float bulletSpeed;

    [SerializeField]
    [Header("총알 반환 시간")]
    private float returnTime;

    private GameObject shooter; //총 
    float rotX;
    private GameObject playerObject;    //플레이어
    private int facingDir = 1;  //바라보는 방향 (1 = 오른쪽, -1 = 왼쪽)

    Camera cam; //마우스 위치 가져오기 위한 카메라

    //풀링
    Queue<GameObject> bullets = new Queue<GameObject>();

    #region 풀링

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
    IEnumerator ObjectDequeue(Queue<GameObject> bulletList) //총알 호출 및 발사
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

    #region 시작 
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

    IEnumerator Controller()    //총알 발사 코루틴
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

    Vector3 GetRot()  //총알 발사 각도 
    {
        //마우스 방향으로 발사
        var mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Input.mousePosition.z));
        var vec = mousePosition - playerObject.transform.position;
        var dir = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;

        Vector3 rot = new Vector3(0, 0, dir);
        return rot;
    }

    private void ShooterRot()   //총 각도
    {
        Vector3 rot = GetRot();

        if (rot.z >= 90 || rot.z <= -90)
        {this.GetComponent<SpriteRenderer>().flipY = true;}
        else
        { this.GetComponent<SpriteRenderer>().flipY = false; }

        shooter.transform.rotation = Quaternion.Euler(rot);
    }

}
