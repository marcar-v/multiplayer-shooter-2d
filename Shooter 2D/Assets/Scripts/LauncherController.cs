using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LauncherController : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject _connectedCanvas;
    [SerializeField] GameObject _disconnectedText;

    public void OnClick_ConnectButton()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        _connectedCanvas.SetActive(true);
        this.gameObject.SetActive(false);
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        _disconnectedText.SetActive(true);
    }
    public override void OnJoinedLobby()
    {
        if(_disconnectedText.activeSelf)
        {
            _disconnectedText.SetActive(false);
        }
        _connectedCanvas.SetActive(true);
    }
}
