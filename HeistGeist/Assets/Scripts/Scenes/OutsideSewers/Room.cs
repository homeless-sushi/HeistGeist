using Teleport;
using UnityEngine;

namespace Scenes.OutsideSewers
{
    public class Room : MonoBehaviour
    {
        private Teleporter _teleporter;
        private Tunnel[] _tunnels;

        private void Awake()
        {
            _teleporter = GetComponent<Teleporter>();
            _tunnels = GetComponentsInChildren<Tunnel>();
        }

        public void Teleport()
        {
            _teleporter.Teleport();
        }
    }
}