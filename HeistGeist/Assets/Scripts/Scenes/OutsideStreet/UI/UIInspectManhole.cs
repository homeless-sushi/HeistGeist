using UnityEngine;

namespace Scenes.OutsideStreet.UI
{
    public class UIInspectManhole : MonoBehaviour
    {
        public void Display()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
