using System.Collections.Generic;
using TDShooter.Configs;
using UnityEngine;

namespace TDShooter
{
    public class LootController : MonoBehaviour//todo �������� ��� ����
    {
        [SerializeField] private List<LootData_SO> _arreyLootData_SO;        

        public List<LootData_SO> Loots => _arreyLootData_SO;

    }
}