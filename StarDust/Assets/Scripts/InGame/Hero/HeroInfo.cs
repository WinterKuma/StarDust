using UnityEngine;

public class HeroInfo : MonoBehaviour
{
    public int infoHealth = 0;
    public int infoAttackPower = 0;
    public int infoAttackRange = 0;
    public int infoMovePoint = 0;

    public int infoManaLimit = 0;
    public int infoDeckLimit = 0;

    public int health = 0;
    public int attackPower = 0;
    public int attackRange = 0;
    public int movePoint = 0;
    public int manaPoint = 0;
    public int maxManaPoint = 0;

    public void SetState()
    {
        health = infoHealth;
        attackPower = infoAttackPower;
        attackRange = infoAttackRange;
        movePoint = 0;
        manaPoint = 0;
        maxManaPoint = 0;
    }
}
