using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    [Range(1, 15)]
    public float velocidade = 3.0f;
    private Vector3 direcao;

    // Start is called before the first frame update
    void Start()
    {
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);
        direcao = new Vector3(dirX, dirY).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

        if (posicaoViewport.x < 0 || posicaoViewport.x > 1)
        {
            direcao = new Vector3(-direcao.x, direcao.y);
        }
        if (posicaoViewport.y < 0 || posicaoViewport.y > 1)
        {
            direcao = new Vector3(direcao.x, -direcao.y);
        }
        transform.position += direcao * Time.deltaTime * velocidade;

    }
}
