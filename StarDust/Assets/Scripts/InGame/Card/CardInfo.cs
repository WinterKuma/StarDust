public class CardInfo
{
    enum CardType
    {
        Normal,
        Counter,
        Ultimate
    }

    enum CardRarity
    {
        Normal,
        Rare,
        Epic
    }

    CardType type = CardType.Normal;
    CardRarity rarity = CardRarity.Normal;
}
