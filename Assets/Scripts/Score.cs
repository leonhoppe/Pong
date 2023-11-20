using UnityEngine;

namespace Pong {
    [CreateAssetMenu(fileName = "Scores", menuName = "Pong/ScoreStateManager", order = 0)]
    public class Score : ScriptableObject {
        public float highScore;
    }
}