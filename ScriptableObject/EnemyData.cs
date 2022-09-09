using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "EnemyData", order = 51)]
public class EnemyData : ScriptableObject
{
    [Header("Information")]
    [SerializeField] private string _name;
    [SerializeField] private string _type;

    [Header("Enemy Status")]
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _enemyLevel;

    [Header("Atack")]
    [SerializeField] private float _damage;
    [SerializeField] private float _distance;
    [SerializeField] private float _fireRate;

    [Header("On Die")]
    [SerializeField] private float _droppedEXP;
    [SerializeField] private GameObject[] _droppedItem;

    public string Name { get => _name; }
    public string Type { get => _type; }
    public float MaxHealth { get => _maxHealth; }
    public float EnemyLevel { get => _enemyLevel; }
    public float Damage { get => _damage; }
    public float Distance { get => _distance; }
    public float FireRate { get => _fireRate; }
    public float DroppedEXP { get => _droppedEXP; }
    public GameObject[] DroppedItem { get => _droppedItem; }
}
