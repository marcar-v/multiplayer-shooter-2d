using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _maxHealth = 10;
    float _currentHealth;
    [SerializeField] Image _healthBar;
    [SerializeField] GameObject _bulletPrefab;

    private void Start()
    {
        if(GetComponent<PhotonView>().IsMine)
        {
            _currentHealth = _maxHealth;
            UpdateHealthBar();
        }
    }

    void UpdateHealthBar()
    {
        _healthBar.fillAmount = _currentHealth / _maxHealth;
    }

    [PunRPC]
    public void TakeDamage(float damage)
    {
        damage = 1;
        if(!GetComponent <PhotonView>().IsMine)
        {
            return;
        }

        _currentHealth -= damage;
        if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        UpdateHealthBar();
    }
}
