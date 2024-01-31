using TMPro;
using UnityEngine;

    
    public class UIManager : MonoBehaviour
    {
        private GameManager _gameManager;
        public GameObject startButton;
           private void Awake()
            {
                _gameManager = GameManager.Instance;
            }
    
            public void StartGame()
            {
                startButton.SetActive(false);
            }
    
            public void StopGame()
            {
                startButton.SetActive(true);
            }
    
    }