using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    public float velocidade = 5;

    private Vector3 direcao;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(2.0f, 5.0f);

        direcao = new Vector3(dirX, dirY).normalized;

        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        // verifica se o estado atual permite movimentação da bola
        if (gm.gameState == GameManager.GameState.MENU)
        {
            ResetPosition();
        }
        if (gm.gameState != GameManager.GameState.GAME) return;

        transform.position += direcao * Time.deltaTime * velocidade;

        Vector2 posicaoViewport =
            Camera.main.WorldToViewportPoint(transform.position);

        if (posicaoViewport.x < 0 || posicaoViewport.x > 1)
        {
            direcao = new Vector3(-direcao.x, direcao.y);
        }
        if (posicaoViewport.y > 1)
        {
            direcao = new Vector3(direcao.x, -direcao.y);
        }
        if (posicaoViewport.y < 0)
        {
            Reset();
        }
    }

    private void ResetPosition()
    {
        Vector3 playerPosition =
            GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = playerPosition + new Vector3(0, 0.5f, 0);

        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(2.0f, 5.0f);

        direcao = new Vector3(dirX, dirY).normalized;
    }

    private void Reset()
    {
        ResetPosition();
        gm.vidas--;
        if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(1.0f, 5.0f);
            direcao = new Vector3(dirX, dirY).normalized;
        }
        else if (collision.gameObject.CompareTag("Bloco"))
        {
            direcao = new Vector3(direcao.x, -direcao.y);
            gm.pontos++;
        }
    }
}
