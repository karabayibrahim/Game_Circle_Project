using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public PlayerController Player;
    public DataBase DataBase;

    private GameState _gameState;

    public GameState GameState
    {
        get
        {
            return _gameState;
        }
        set
        {
            if (GameState==value)
            {
                return;
            }
            _gameState = value;
            OnGameStatusChanged();
        }
    }

    private void OnGameStatusChanged()
    {
        switch (GameState)
        {
            case GameState.START:
                break;
            case GameState.MÝDDLE:
                break;
            case GameState.LAST:
                break;
            default:
                break;
        }
    }

    void Start()
    {
        Assigment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Assigment()
    {
        Player = FindObjectOfType<PlayerController>();
    }
}
