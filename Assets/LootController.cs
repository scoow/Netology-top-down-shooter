using System.Collections;
using System.Collections.Generic;
using TDShooter;
using UnityEngine;

public class LootController : MonoBehaviour
{
    [SerializeField] private List<LootData_SO> _arreyLootData_SO;

    public List<LootData_SO>  Loots => _arreyLootData_SO;
}
