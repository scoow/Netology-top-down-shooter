using TDShooter.Characters;
using TDShooter.enums;
using UnityEngine;

public class Spawn_BossAssistance : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _spawnPoint1;  

    [SerializeField] private Enemy_NavMeshMove _enemyAssist;

    [SerializeField] private SpawnAssistant _spawnAssistant;
    private void SpawnAssist() //���������� ����� ������� � ��������
    {
        _spawnAssistant.SpawnEnemy(transform.position, �haracterType.BossAssistant);
        //Instantiate(_enemyAssist, _spawnPoint1.transform,true);        
    }  
}