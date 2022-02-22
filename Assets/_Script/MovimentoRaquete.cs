using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour
{
    [Range(0, 15)]
    public float velocidade = 10.0f;

    private Vector3 direcao;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (gm.gameState == GameManager.GameState.MENU)
            {
                ResetPosition();
            }
            if (gm.gameState != GameManager.GameState.GAME) return;

            float inputX = Input.GetAxis("Horizontal");
            velocidade = 5 + 10 * (gm.pontos / 30);
            transform.position +=
                new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;

            if (
                Input.GetKeyDown(KeyCode.Escape) &&
                gm.gameState == GameManager.GameState.GAME
            )
            {
                gm.ChangeState(GameManager.GameState.PAUSE);
            }
        }
    }

    private void ResetPosition()
    {
        transform.position = new Vector3(0, -5, 0);
    }
}
