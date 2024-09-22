using DG.Tweening;
using UnityEngine;

namespace CodeBase.GamePlay.Levels
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private float _minOpenDuration = 1f;
        [SerializeField] private float _maxOpenDuration = 2f;
        [SerializeField] private float _openAngle;

        public void Open()
        {
            float openDuration = Random.Range(_minOpenDuration, _maxOpenDuration);
            Vector3 targetRotation = new Vector3(0, _openAngle, 0);

            transform.DOLocalRotate(targetRotation, openDuration)
                .SetEase(Ease.OutQuad);
        }
    }
}