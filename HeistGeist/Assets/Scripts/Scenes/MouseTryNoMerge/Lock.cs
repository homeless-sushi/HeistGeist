using UnityEngine;

namespace Scenes.MouseTryNoMerge
{
    public class Lock : MonoBehaviour
    {
        [SerializeField] GameObject rightKey;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SetRightAnswer(GameObject right)
        {
            rightKey = right;
            
        }
        
        // void OnCollisionStay(Collision collisionInfo)
        // {
        //     // Debug-draw all contact points and normals
        //     foreach (ContactPoint contact in collisionInfo.contacts)
        //     {
        //         Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
        //     }
        //
        //     // if (collisionInfo. = rightKey)
        //     // {
        //     //     
        //     // }
        // }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == rightKey)
            {
                print("Right key");
            }
            else
            {
                print("Key Error!!!");
            }
            print(other.gameObject.name);
        }
        
        // void OnCollisionStay2D(Collision2D coll) {
        //     Debug.Log ("------正在碰撞-------------");
        //     Debug.Log(coll.gameObject.name);
        // }

    }
}
