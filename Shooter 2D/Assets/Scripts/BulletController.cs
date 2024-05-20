using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class BulletController : MonoBehaviourPun
{
    [SerializeField] float _bulletSpeed = 10f;
    float _destroyTime = 2f;
    SpriteRenderer _bulletSprite;
    bool _shootLeft = false;
    public bool shootLeft {  get { return _shootLeft; } set {  _shootLeft = value; } }


    private void Awake()
    {
        _bulletSprite = GetComponent<SpriteRenderer>();
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(_destroyTime);
        GetComponent<PhotonView>().RPC("DestroyRPC", RpcTarget.AllBuffered);
    }

    private void Update()
    {
        if(!_shootLeft)
        {
            transform.Translate(Vector3.right * _bulletSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * _bulletSpeed * Time.deltaTime);
        }
    }

    [PunRPC]
    private void DestroyRPC()
    {
        Destroy(gameObject);
    }
    [PunRPC]
    public void ChangeDirection()
    {
        _shootLeft = true;
        _bulletSprite.flipX = true;
    }
}
