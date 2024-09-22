using DG.Tweening;
using UnityEngine;

namespace CodeBase.GamePlay.Levels
{
    public class Flag : MonoBehaviour
    {
        [SerializeField] private float _rotationDuration = 1f;
        [SerializeField] private Vector3 _targetRotation = new Vector3(0, 0, 0);
        public void Rotate()
        {
            transform.DORotate(_targetRotation, _rotationDuration, RotateMode.FastBeyond360).SetEase(Ease.OutQuad);
        }
    }
}