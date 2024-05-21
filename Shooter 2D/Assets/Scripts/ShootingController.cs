using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] AudioSource _shootSound;
    [SerializeField] Transform _spawnBulletRight;
    [SerializeField] Transform _spawnBulletLeft;
    [SerializeField] PlayerController _playerController;
    PhotonView _photonView;
    GameObject _playerBullet;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (_photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale > 0)
            {
                Shoot();
                _shootSound.Play();
            }
        }
        else
        {
            return;
        }
    }

    public void Shoot()
    {
        if (_playerController.playerSprite.flipX == true)
        {
            _playerBullet = PhotonNetwork.Instantiate(_bulletPrefab.name, _spawnBulletLeft.position, Quaternion.identity);

        }
        else
        {
            _playerBullet = PhotonNetwork.Instantiate(_bulletPrefab.name, _spawnBulletRight.position, Quaternion.identity);

        }

        if (_playerController.playerSprite.flipX == true)
        {
            _playerBullet.GetComponent<PhotonView>().RPC("ChangeDirection", RpcTarget.AllBuffered);
        }
    }
}
