using UnityEngine;

namespace Scenes.VaultArt
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private int[] code;

        public void SetCode(int[] code)
        {
            this.code = code;
        }
    }
}
