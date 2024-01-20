using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 25f;

    private void OnEnable()
    {
        StartCoroutine(ShootBullet());
    }

    IEnumerator ShootBullet()   //�Ѿ� �߻� �Լ�
    {
        while (true)
        {
            this.gameObject.transform.Translate(Vector2.right * Time.deltaTime * bulletSpeed);
            yield return null;
        }
    }

}//end class