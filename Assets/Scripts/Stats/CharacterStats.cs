using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;
    public PlayerStats player;
    public EnemyStats enemy;

    void Awake()
    {
        currentHealth = maxHealth;
        if (gameObject.tag == "Enemy")
            enemy = GetComponent<EnemyStats>();
        if (gameObject.tag == "Player")
            player = GetComponent<PlayerStats>();
    }
    
    public void TakeDamage (int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Player")
                player.Die();
            else
                enemy.Die();
        }
    }
}
