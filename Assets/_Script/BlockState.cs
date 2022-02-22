using UnityEngine;

public class BlockState
{
    public int durability;

    public BlockState()
    {
        durability = this.GetDurability();
    }

    public void DecreaseDurability()
    {
        this.durability--;
    }

    public Color GetColor()
    {
        switch (this.durability)
        {
            case 4:
                return new Color(1, 0, 0, 1);
            case 3:
                return new Color(0, 1, 0, 1);
            case 2:
                return new Color(0, 0, 1, 1);
            case 1:
                return new Color(1, 1, 1, 1);
            default:
                return new Color(1, 1, 1, 1);
        }
    }

    private int GetDurability()
    {
        return Random.Range(1, 5);
    }
}
