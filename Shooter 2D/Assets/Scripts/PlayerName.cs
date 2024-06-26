using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerName : MonoBehaviour
{
    [SerializeField] TMP_InputField _playerName;
    [SerializeField] Button _setNameButton;
    [SerializeField] GameObject _doneText;

    public void OnTFChange()
    {
        if(_playerName.text.Length > 2)
        {
            _setNameButton.interactable = true;
        }
        else
        {
            _setNameButton.interactable = false;
        }
    }

    public void OnClick_SetName()
    {
        PhotonNetwork.NickName = _playerName.text;
        _doneText.SetActive(true);
    }
}
