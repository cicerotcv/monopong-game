using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
    public GameObject Block;

    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += BuildBlocks;
        BuildBlocks();
    }

    void BuildBlocks()
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Vector3 posicao =
                        new Vector3(-12 + 1.75f * i, 3 + 1.5f * j);
                    Instantiate(Block, posicao, Quaternion.identity, transform);
                }
            }
        }
    }

    void Update()
    {
        if (
            transform.childCount <= 0 &&
            gm.gameState == GameManager.GameState.GAME
        )
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }
}
