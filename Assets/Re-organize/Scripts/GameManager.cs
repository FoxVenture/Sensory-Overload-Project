using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState gameState;

    public static event Action<GameState> OnGameStateChanged;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.GameMenu);
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void UpdateGameState(GameState newState)
    {
        gameState = newState;

        switch (newState)
        {
            case GameState.GameMenu:
                //Do something
                break;
            case GameState.Intro:
                FindObjectOfType<AudioManager>().Play("Talking Ambience");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(gameState);
    }
}

public enum GameState
{
    GameMenu,
    Intro,
    StartGame,
    DistractionStage1,
    DistractionStage2,
    DistractionStage3,
    DistractionStage4,
    DistractionStage5,
    EndGame
}
