using System;
using UnityEngine;
namespace GeometryDash
{
    [Serializable]
    public enum ParticleType
    {
        DeadParticle,
        ChangeModeParticle,
        MoveParticle
    }
    [Serializable]
    public struct Particle
    {
        public string name;
        public ParticleType particleType;
        public GameObject particlePrefab;
    }

    public class ParticleManager : MonoBehaviour
    {
        public Particle[] particles;

        /// <summary>
        /// bu metod tek kullanimlik particle effectleri tetikler dead,modechange,portal...
        /// </summary>
        /// <param name="type">ParticleType enum</param>
        public void PlayParticleAtPosition(ParticleType type, Transform transform)
        {
            Particle p = Array.Find(particles, particle => particle.particleType == type);
            GameObject particleObject = Instantiate(p.particlePrefab);
            particleObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
            //TODO: object pool kullanildigi zaman partcilebehaviour disable olarak ayarlanacak
        }

        public void DeadParticle(GameManager manager)
        {
            PlayParticleAtPosition(ParticleType.DeadParticle, manager.GetPlayer().transform);
        }
    }
}