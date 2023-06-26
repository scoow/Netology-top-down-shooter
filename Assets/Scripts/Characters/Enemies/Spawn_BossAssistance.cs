using TDShooter.Characters;
using TDShooter.enums;
using UnityEngine;

public class Spawn_BossAssistance : MonoBehaviour
{
    [SerializeField] private Enemy_NavMeshMove _enemyAssist;

    private SpawnAssistant _spawnAssistant;
    private void Start()
    {
        _spawnAssistant = FindFirstObjectByType<SpawnAssistant>();
    }
    private void SpawnAssist() //���������� ����� ������� � ��������
    {
        _spawnAssistant.SpawnEnemy(transform.position, �haracterType.BossAssistant);
        //Instantiate(_enemyAssist, _spawnPoint1.transform,true);        
    }  
}