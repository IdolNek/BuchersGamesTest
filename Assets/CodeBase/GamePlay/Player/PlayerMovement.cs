using System.Collections.Generic;
using CodeBase.GamePlay.Levels;
using UnityEngine;

namespace CodeBase.GamePlay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        public float speed = 5f;
        public float rotationSpeed = 180f;
        private int _currentPointIndex = 0;

        private List<PivotPoint> _pivotPoints;
        private bool _isStop;

        public void Initialize(List<PivotPoint> pivotPoints)
        {
            _pivotPoints = pivotPoints;
        }

        public void SetStop() => _isStop = true;

        public void SetStart() => _isStop = false;

        private void Update()
        {
            if(_isStop) return;
            
            if (_pivotPoints == null || _pivotPoints.Count == 0 || _currentPointIndex >= _pivotPoints.Count)
                return;

            MoveTowardsPoint();
        }

        private void MoveTowardsPoint()
        {
            Transform targetPoint = _pivotPoints[_currentPointIndex].transform;

            Vector3 direction = (targetPoint.position - transform.position);

            Vector3 normalizedDirection = direction.normalized;

            transform.position += normalizedDirection * speed * Time.deltaTime;

            Quaternion targetRotation = Quaternion.LookRotation(normalizedDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(targetPoint.position.x, 0, targetPoint.position.z)) < 0.1f)
            {
                _currentPointIndex++;

                if (_currentPointIndex >= _pivotPoints.Count)
                {
                    OnGameEnd();
                }
            }
        }

        private void OnGameEnd()
        {
            _playerView.Dance();
        }
    }
}