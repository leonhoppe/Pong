using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pong {
    public class Ball : MonoBehaviour {
        public Collider2D leftCollider;
        public Collider2D rightCollider;
        public Collider2D topCollider;
        public Collider2D bottomCollider;

        public Collider2D playerCollider;
        public Collider2D enemyCollider;

        public float speed;
        public float speedIncreaseRate;

        public TextMeshProUGUI score;
        public TextMeshProUGUI highScore;
        public Score scoreManager;

        private Vector3 _direction = new(-1, 1, 0);
        [NonSerialized] public bool GameStarted = false;

        private void Start() {
            highScore.SetText(scoreManager.highScore.ToString());
        }

        private void Update() {
            if (Input.anyKey) GameStarted = true;
            
            if (!GameStarted) return;
            transform.position += _direction * (speed * Time.deltaTime);

            if (Input.GetButtonDown("Cancel")) {
                GameOver();
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other == topCollider) _direction.y = -1;
            else if (other == bottomCollider) _direction.y = 1;
            
            else if (other == playerCollider) {
                _direction.x = 1;
                speed *= speedIncreaseRate;
                
                var currScore = Convert.ToInt32(score.GetParsedText());
                score.SetText((currScore + 1).ToString());
            }
            else if (other == enemyCollider) {
                _direction.x = -1;
                speed *= speedIncreaseRate;
            }
            
            else if (other == leftCollider || other == rightCollider) {
                GameOver();
            }
        }

        private void GameOver() {
            var currScore = Convert.ToInt32(score.GetParsedText());
            var currHighScore = Convert.ToInt32(highScore.GetParsedText());
            if (currScore > currHighScore) scoreManager.highScore = currScore;

            SceneManager.LoadScene(gameObject.scene.name);
        }
    }
}