using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStatus _playerStatus;
    private PlayerAnimationState _playerAnimationStatus;
    private Animator _anim;
    private float _playerStatusAmount;
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;

    public float SwerveSpeed;
    public float RunSpeed;
    public float MoveFactorX => _moveFactorX;

    public float PlayerStatusAmount
    {
        get
        {
            return _playerStatusAmount;
        }
        set
        {
            if (PlayerStatusAmount==value)
            {
                return;
            }
            _playerStatusAmount = value;
        }
    }

    public PlayerStatus PlayerStatus
    {
        get
        {
            return _playerStatus;
        }
        set
        {
            if (PlayerStatus==value)
            {
                return;
            }
            _playerStatus = value;
            OnStatusChanged();
        }
    }

    public PlayerAnimationState PlayerAnimationState
    {
        get
        {
            return _playerAnimationStatus;
        }
        set
        {
            if (PlayerAnimationState == value)
            {
                return;
            }
            _playerAnimationStatus = value;
            OnAnimationStatusChanged();
        }
    }

    private void OnAnimationStatusChanged()
    {
        switch (PlayerAnimationState)
        {
            case PlayerAnimationState.IDLE:
                break;
            case PlayerAnimationState.SADWALK:
                RunSpeed = 2f;
                break;
            case PlayerAnimationState.NORMALWALK:
                RunSpeed = 4f;
                break;
            case PlayerAnimationState.GOODWALK:
                RunSpeed = 6f;
                break;
            case PlayerAnimationState.VICTORY:
                break;
            case PlayerAnimationState.REJECTED:
                break;
            case PlayerAnimationState.STATUSCHANGED:
                break;
            default:
                break;
        }
    }

    private void OnStatusChanged()
    {
        switch (PlayerStatus)
        {
            case PlayerStatus.BAD:
                break;
            case PlayerStatus.NORMAL:
                break;
            case PlayerStatus.GOOD:
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ICollactable>()!=null)
        {
            other.GetComponent<ICollactable>().DoCollect();
        }
    }

    void Start()
    {
        PlayerAnimationState = PlayerAnimationState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        MoveSystem();
    }

    private void MoveSystem()
    {
        float swerveAmount = Time.deltaTime * SwerveSpeed * MoveFactorX;
        transform.Translate(swerveAmount, 0, 0);
        transform.Translate(0, 0, RunSpeed * Time.deltaTime);
    }

    private void MovementInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }
    }

    
}
