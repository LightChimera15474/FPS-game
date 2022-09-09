using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;

    private float _health;

    private void Start()
    {
        _health = _enemyData.MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health-= damage;
        if(_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
