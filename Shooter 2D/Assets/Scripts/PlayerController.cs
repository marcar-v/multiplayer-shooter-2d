using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class PlayerController : MonoBehaviourPun, IPunObservable
{
    [SerializeField] PhotonView _photonView;
    
    [Header("Movement")]
    [SerializeField] float _speed = 10;

    [Header("Smooth Movement")]
    private Vector3 _smoothMove;
    [SerializeField] float _smoothTime = 10;

    [Header("Jump")]
    [SerializeField] float _jumpForce = 5;
    [SerializeField] LayerMask _groundLayer;
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rb;
    private int _remainingJumps;
    private int _totalJumps = 1;


    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _remainingJumps = _totalJumps;
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            PlayerMovement();
            PlayerJump();
        }
        else
        {
            SmoothMovement();
        }
    }

    void PlayerMovement()
    {
        Vector3 _movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        transform.position += _movement * _speed * Time.deltaTime;
    }
    bool isGrounded()
    {
        RaycastHit2D _raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, new Vector2(_boxCollider2D.bounds.size.x, _boxCollider2D.bounds.size.y), 0f, Vector2.down, 0.2f, _groundLayer);
        return _raycastHit2D.collider != null;
    }

    void PlayerJump()
    {
        if (isGrounded())
        {
            _remainingJumps = _totalJumps;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _remainingJumps > 0)
        {
            _remainingJumps--;
            _rb.velocity = new Vector2(_rb.velocity.x, 0f);
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
    private void SmoothMovement()
    {
        transform.position = Vector3.Lerp(transform.position, _smoothMove, Time.deltaTime * _smoothTime);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }

        else if(stream.IsReading)
        {
            _smoothMove = (Vector3)stream.ReceiveNext();
        }
    }
}
