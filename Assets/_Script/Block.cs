using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    SpriteRenderer sprite;

    BlockState blockState;

    public TextMesh durabilityText;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        blockState = new BlockState();
        sprite.color = blockState.GetColor();
    }

    void Update()
    {
        durabilityText.text = $"{blockState.durability}";
        sprite.color = blockState.GetColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        blockState.DecreaseDurability();
        if (blockState.durability <= 0)
        {
            Destroy (gameObject);
        }
    }
}
