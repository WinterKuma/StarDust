using UnityEngine;

public class CardInfo
{
    public enum CardType
    {
        Normal,
        Counter,
        Ultimate
    }

    public enum CardRarity
    {
        Normal,
        Rare,
        Epic
    }

    CardType type = CardType.Normal;
    CardRarity rarity = CardRarity.Normal;
    int cost;
    int coolTime;
    string name;
    string effectString;
    Sprite Image;
}
