using UnityEngine;

namespace GeometryDash
{
    [RequireComponent(typeof(ParticleSystem))]
    [DisallowMultipleComponent]
    public class ParticleSystemBehaviour : MonoBehaviour
    {
        public enum ClearBehavior
        {
            Disable,
            Destroy
        }
        [Tooltip("Particle system bittikten sonra yapilacak eylem")]
        public ClearBehavior clearBehavior = ClearBehavior.Destroy;

        ParticleSystem rootParticleSystem;

        private void Update()
        {
            if (rootParticleSystem == null)
            {
                rootParticleSystem = this.GetComponent<ParticleSystem>();
            }
            if (!rootParticleSystem.IsAlive(true))
            {
                if (clearBehavior == ClearBehavior.Destroy)
                {
                    GameObject.Destroy(this.gameObject);
                }
                else
                {
                    this.gameObject.SetActive(false); //object pool eklendigi zaman bu secenek kullanilacak
                }
            }
        }

    }
}
