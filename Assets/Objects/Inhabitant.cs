using UnityEngine;

public abstract class Inhabitant
{
    protected string name;
    protected int hp;
    protected int maxHp; 
    protected int ac;

    public Inhabitant(string name, int hp, int ac)
    {
        this.name = name;
        this.hp = hp;
        this.maxHp = hp; 
        this.ac = ac;
    }

    public string getName()
    {
        return this.name;
    }

    public int getAC()
    {
        return this.ac;
    }

    public void takeDamage(int dmg)
    {
        this.hp -= dmg;
        if (this.hp < 0) this.hp = 0; 
    }

    public bool isDead()
    {
        return this.hp <= 0;
    }

    public int getHP()
    {
        return this.hp;
    }

    public int getMaxHP() 
    {
        return this.maxHp;
    }
}
