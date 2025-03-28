using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class Fight
{
    private HealthBarController playerHealthBar;
    private HealthBarController monsterHealthBar;

    private Inhabitant attacker;
    private Inhabitant defender;

    private Monster theMonster;
    private bool fightOver = false;

    public Fight(Monster m)
    {
        this.theMonster = m;

        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
            this.attacker = m;
            this.defender = Core.thePlayer;
        }
        else
        {
            Debug.Log("Player goes first");
            this.attacker = Core.thePlayer;
            this.defender = m;
        }
    }

    public bool isFightOver()
    {
        return this.fightOver;
    }

    public void takeASwing(GameObject playerGameObject, GameObject monsterGameObject)
    {
        if (fightOver) return;

        int attackRoll = Random.Range(0, 20) + 1;
        Debug.Log("Attack Roll: " + attackRoll);
        Debug.Log("Defender AC: " + this.defender.getAC());

        if (attackRoll >= this.defender.getAC())
        {
            int damage = Random.Range(1, 6);
            this.defender.takeDamage(damage);

            Debug.Log(this.attacker.getName() + " hits " + this.defender.getName() + " for " + damage + " damage!");

            playerHealthBar.SetHealth(Core.thePlayer.getHP(), Core.thePlayer.getMaxHP());
            monsterHealthBar.SetHealth(theMonster.getHP(), theMonster.getMaxHP());

            if (this.defender.isDead())
            {
                this.fightOver = true;
                Debug.Log(this.attacker.getName() + " killed " + this.defender.getName());

                if (this.defender is Player)
                {
                    Debug.Log("Player died");
                    playerGameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("Monster died");
                    GameObject.Destroy(monsterGameObject);
                }

                return;
            }
        }
        else
        {
            Debug.Log(this.attacker.getName() + " missed " + this.defender.getName());
        }

  
        Inhabitant temp = this.attacker;
        this.attacker = this.defender;
        this.defender = temp;
    }

    public void startFight(GameObject playerGameObject, GameObject monsterGameObject, HealthBarController playerHB, HealthBarController monsterHB)
    {
        this.playerHealthBar = playerHB;
        this.monsterHealthBar = monsterHB;

        playerHealthBar.SetHealth(Core.thePlayer.getHP(), Core.thePlayer.getMaxHP());
        monsterHealthBar.SetHealth(theMonster.getHP(), theMonster.getMaxHP());
    }
}
