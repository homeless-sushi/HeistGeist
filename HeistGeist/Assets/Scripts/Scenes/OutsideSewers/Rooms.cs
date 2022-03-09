using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scenes.OutsideSewers
{
    [Serializable]
    public class Rooms
    {
        [SerializeField]
        private Room[] rooms1Tunnel;
        [SerializeField]
        private Room[] rooms2Tunnel;
        [SerializeField]
        private Room[] rooms3Tunnel;
        [SerializeField]
        private Room[] rooms4Tunnel;

        public Room GetRandomRoom(int numTunnels)
        {
            var rooms = GetRooms(numTunnels);
            return rooms[Random.Range(0, rooms.Length)];
        }

        private Room[] GetRooms(int numTunnels)
        {
            return new[]
            {
                rooms1Tunnel,
                rooms2Tunnel,
                rooms3Tunnel,
                rooms4Tunnel
            }[numTunnels - 1];
        }
    }
}