using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField _createRoom;
    [SerializeField] TMP_InputField _joinRoom;
    public void OnClick_CreateRoom()
    {
        PhotonNetwork.CreateRoom(_createRoom.text, new RoomOptions { MaxPlayers = 4 }, null);
    }

    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinRoom.text, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room joined success");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room joined failed" + returnCode + "Message" + message);

    }
}
