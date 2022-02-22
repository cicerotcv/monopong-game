using UnityEngine;

public class BlockType
{
    private enum TypeOptions
    {
        RED,
        GREEN,
        BLUE,
        WHITE
    }

    TypeOptions type;

    public Color color;

    public int durability;

    public BlockType()
    {
        type = this.GetType();
        color = this.GetColor(type);
        durability = this.GetDurability(type);
    }

    private int GetDurability(TypeOptions type)
    {
        switch (type)
        {
            case TypeOptions.RED:
                return 4;
            case TypeOptions.GREEN:
                return 3;
            case TypeOptions.BLUE:
                return 2;
            case TypeOptions.WHITE:
                return 1;
            default:
                return 1;
        }
    }

    private Color GetColor(TypeOptions type)
    {
        switch (type)
        {
            case TypeOptions.RED:
                return new Color(1, 0, 0, 1);
            case TypeOptions.GREEN:
                return new Color(0, 1, 0, 1);
            case TypeOptions.BLUE:
                return new Color(0, 0, 1, 1);
            case TypeOptions.WHITE:
                return new Color(1, 1, 1, 1);
            default:
                return new Color(1, 1, 1, 1);
        }
    }

    new private TypeOptions GetType()
    {
        int enumLength = System.Enum.GetValues(typeof (TypeOptions)).Length;
        return (TypeOptions) Random.Range(0, enumLength);
    }
}
