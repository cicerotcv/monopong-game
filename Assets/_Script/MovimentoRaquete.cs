using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour
{
    [Range(0, 15)]
    public float velocidade = 5.0f;

    private Vector3 direcao;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        // transform.position += new Vector3(inputX, 0, 0);
        // transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime;
        transform.position +=
            new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
    }
}
