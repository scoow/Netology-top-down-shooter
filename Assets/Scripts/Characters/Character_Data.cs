using System.Collections;
using System.Collections.Generic;
using TDShooter;
using TDShooter.enums;
using UnityEngine;

public class Character_Data : MonoBehaviour
{
    [SerializeField] private ÑharacterData_SO _characterData_SO;
    private int _hp;
    private float _armor;
    private float _speedMove;
    private float _missChance;
    private float _criticalDamageChance;
    private ÑharacterType _ñharacterType;   

    public int Hp { get => _hp; set => _hp = value; }
    public float Armor { get => _armor; set => _armor = value; }
    public float SpeedMove { get => _speedMove; set => _speedMove = value; }
    public float MissChance { get => _missChance; set => _missChance = value; }
    public float CriticalDamageChance { get => _criticalDamageChance; set => _criticalDamageChance = value; }
    public ÑharacterType ÑharacterType { get => _ñharacterType; set => _ñharacterType = value; }
    public ÑharacterData_SO CharacterData_SO { get => _characterData_SO;}

    protected virtual void Awake()
    {
        Hp = CharacterData_SO.Health;
        Armor = CharacterData_SO.Armor;
        SpeedMove = CharacterData_SO.SpeedMove;
        MissChance = CharacterData_SO.MissChance;
        CriticalDamageChance = CharacterData_SO.CriticalDamageChance;
        ÑharacterType = CharacterData_SO.CharacterType;        
    }
}