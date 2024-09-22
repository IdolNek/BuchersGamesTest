using UnityEngine;

namespace CodeBase.GamePlay.Player
{
    public class PlayerProgress : MonoBehaviour
    {
        [SerializeField] private int _midlleCount;
        [SerializeField] private int _richCount;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private BarView _barView;
        [SerializeField] private GameObject fireworkPrefab; // Префаб фейерверка
        [SerializeField] private Transform fireworkSpawnPoint; // Точка спавна фейерверка

        private int _moneyCount;

        private void Start()
        {
            _playerView.SetPoor();
            _barView.SetPoorText();
        }

        public void AddMoney()
        {
            _moneyCount++;
            CheckRich();
            _barView.SetFillProgress(_moneyCount / (float)_richCount);
        
            SpawnFirework();
        }

        public void RemoveMoney()
        {
            _moneyCount--;
            CheckRich();
            _barView.SetFillProgress(_moneyCount / (float)_richCount);
        }

        private void CheckRich()
        {
            if (_moneyCount >= _midlleCount && _moneyCount < _richCount)
            {
                _playerView.SetGood();
                _barView.SetGoodText();
            }
            if (_moneyCount >= _richCount)
            {
                _playerView.SetPerfect();
                _barView.SetPerfectText();
            }
        }

        private void SpawnFirework()
        {
            Instantiate(fireworkPrefab, fireworkSpawnPoint.position, Quaternion.identity);
        }

        public void SetMultiplier(int multiplier)
        {
            _moneyCount *= multiplier;
            CheckRich();
            _barView.SetFillProgress(_moneyCount / (float)_richCount);
        }
    }
}