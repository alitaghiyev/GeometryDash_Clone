using UnityEngine;
namespace GeometryDash
{
    public class PlayerRespawner : MonoBehaviour
    {
        [SerializeField] private Transform _respawnTransform;

        GameObject Player;


        /// <summary>
        /// Restart even tarafindan tetikenir
        /// </summary>
        /// <param name="manager"></param>
        public void WaitRespawner(GameManager manager)
        {
            Player = manager.GetPlayer();
            float delay = manager.GetResetTime();
            ClosePlayer();
            this.Wait(delay, () => RespawnPlayer());
        }

        public void RespawnPlayer()
        {
            Player.transform.SetPositionAndRotation(_respawnTransform.position, _respawnTransform.rotation);
            Player.SetActive(true);
        }

        public void ClosePlayer()
        {
            Player.SetActive(false);
        }
    }
}
