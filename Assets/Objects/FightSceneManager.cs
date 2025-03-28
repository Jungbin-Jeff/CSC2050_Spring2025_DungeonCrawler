using UnityEngine;

public class FightSceneManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;

    public HealthBarController playerHealthBar;
    public HealthBarController monsterHealthBar;

    private Fight fight;
    private float timeSinceLastAttack = 0f;

    void Start()
    {
        Monster monsterScript = monster.GetComponent<Monster>();
        fight = new Fight(monsterScript);
        fight.startFight(player, monster, playerHealthBar, monsterHealthBar);
    }

    void Update()
    {
        if (fight.isFightOver()) return;

        timeSinceLastAttack += Time.deltaTime;

        if (timeSinceLastAttack >= 1.0f)
        {
            fight.takeASwing(player, monster);
            timeSinceLastAttack = 0f;
        }
    }
}
