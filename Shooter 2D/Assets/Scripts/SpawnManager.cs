using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _playerPrefab;
    private void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        if(_playerPrefab != null)
        {
            int _randomX = Random.Range(-6, 6);
            PhotonNetwork.Instantiate(_playerPrefab.name, new Vector2(_randomX, 0), _playerPrefab.transform.rotation);

        }
    }
}
