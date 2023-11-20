using UnityEngine;

namespace Pong {
    public class Enemy : MonoBehaviour {
        public Ball ball;
        public Player player;

        private void Update() {
            if (!ball.GameStarted) return;
            
            var ballPos = ball.transform.position;
            var pos = transform.position;
            
            float direction = 1;
            if (ballPos.y < pos.y) direction = -1;

            pos.y = Mathf.Clamp(pos.y + (direction * player.speed * Time.deltaTime), player.bottomClamp, player.topClamp);
            transform.position = pos;
        }
    }
}