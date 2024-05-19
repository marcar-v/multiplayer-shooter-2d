using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] GameObject _playerBullet;
    [SerializeField] AudioSource _shootSound;
    [SerializeField] Transform _spawnBulletRight;
    [SerializeField] Transform _spawnBulletLeft;
    [SerializeField] PlayerController _playerController;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale > 0)
        {
            Shoot();
            _shootSound.Play();
        }
    }

    public void Shoot()
    {        
        if(_playerController.playerSprite == true)
        {
            GameObject _bulletPrefab = PhotonNetwork.Instantiate(_playerBullet.name, _spawnBulletLeft.position, Quaternion.identity);

        }
        else
        {
            GameObject _bulletPrefab = PhotonNetwork.Instantiate(_playerBullet.name, _spawnBulletRight.position, Quaternion.identity);

        }

        if (_playerController.playerSprite.flipX == true)
        {
            _playerBullet.GetComponent<PhotonView>().RPC("ChangeDirection", RpcTarget.AllBuffered);
        }
    }
}
