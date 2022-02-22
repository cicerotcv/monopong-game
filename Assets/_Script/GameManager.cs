using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public enum GameState
    {
        MENU,
        GAME,
        PAUSE,
        ENDGAME
    }

    public GameState gameState { get; private set; }

    public int vidas;

    public int pontos;

    private static GameManager _instance;

    public delegate void ChangeStateDelegate();

    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        if (gameState == GameState.ENDGAME && nextState == GameState.GAME)
            Reset();
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        this.vidas = 3;
        this.pontos = 0;
    }

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        this.vidas = 3;
        this.pontos = 0;
        this.gameState = GameState.MENU;
    }
}
