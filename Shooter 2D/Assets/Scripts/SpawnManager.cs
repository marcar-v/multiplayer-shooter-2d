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
        PhotonNetwork.Instantiate(_playerPrefab.name, _playerPrefab.transform.position, _playerPrefab.transform.rotation);
    }
}
