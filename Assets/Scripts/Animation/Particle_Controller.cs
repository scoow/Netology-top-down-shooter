using TDShooter.Characters;
using UnityEngine;

public class Particle_Controller : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private ParticleSystem _bloodParticle;


    private void OnEnable()
    {
        character.OnHit += EnableParticle;
    }

    private void OnDisable()
    {
        character.OnHit -= EnableParticle;
    }

    private void EnableParticle()
    {
        _bloodParticle.Play();
    }
}