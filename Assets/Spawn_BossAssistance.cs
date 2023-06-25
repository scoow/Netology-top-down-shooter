using System.Collections;
using System.Collections.Generic;
using TDShooter.Characters;
using UnityEngine;
using Zenject.SpaceFighter;

public class Spawn_BossAssistance : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _spawnPoint1;  

    [SerializeField] private Enemy_NavMeshMove _enemyAssist;


    private void SpawnAssist() //вызывается через событие в анимации
    {
        Instantiate(_enemyAssist, _spawnPoint1.transform,true);        
    }  
}