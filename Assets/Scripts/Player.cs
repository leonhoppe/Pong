using UnityEngine;

namespace Pong {
    public class Player : MonoBehaviour {
        public float topClamp;
        public float bottomClamp;
        public float speed;
        
        private void Update() {
            var movement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            var pos = transform.position;
            pos.y = Mathf.Clamp(pos.y + movement, bottomClamp, topClamp);
            transform.position = pos;
        }
    }
}