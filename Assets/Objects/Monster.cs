public class Monster : Inhabitant
{
    public Monster(string name) : base(name, 15, 8) { }

    public new int getHP()
    {
        return this.hp;
    }

    public new int getMaxHP()
    {
        return this.maxHp;
    }
}
