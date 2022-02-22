using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
    public GameObject Block;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 posicao = new Vector3(-12 + 1.75f * i, 3 + 1.5f * j);
                Instantiate(Block, posicao, Quaternion.identity, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
