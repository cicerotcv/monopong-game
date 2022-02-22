using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    SpriteRenderer sprite;

    BlockType blockType;

    private int durability;

    public TextMesh durabilityText;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        blockType = new BlockType();
        sprite.color = blockType.color;

        durability = blockType.durability;
    }

    void Update()
    {
        durabilityText.text = $"{durability}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        durability--;
        if (durability <= 0)
        {
            Destroy (gameObject);
        }
    }
}
