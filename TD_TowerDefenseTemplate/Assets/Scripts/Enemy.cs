using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public EnemyData enemyData;

    public float speed;
    public float health;

    [SerializeField]
    Image healthBar;

    private bool isDead = false;


    void Start()
    {
        speed = enemyData.speed;
        health = enemyData.startHealth;


        gameObject.GetComponent<Renderer>().material.color = enemyData.color;
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Renderer>())
                child.gameObject.GetComponent<Renderer>().material.color = enemyData.color;
        }

    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / enemyData.startHealth;

        if (health <= 0 && !isDead)
        {
            DeathEffect();
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Spawner.enemiesInWave--;
        GameManager.PlayerScore += enemyData.reward;
        GameManager.PlayerMoney += enemyData.money;
        Destroy(gameObject);
    }

    private void DeathEffect()
    {
        GameObject deathEffect = Instantiate(enemyData.deathEffect, transform.position, transform.rotation);
        Destroy(deathEffect, 1f);
    }
}
