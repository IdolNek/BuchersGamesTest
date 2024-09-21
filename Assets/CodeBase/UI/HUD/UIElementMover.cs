using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIElementMover : MonoBehaviour
{
    [SerializeField] private RectTransform uiElement;
    [SerializeField] private float leftPosition = -500f;
    [SerializeField] private float rightPosition = 500f;
    [SerializeField] private float moveDuration = 2f;
    [SerializeField] private float pauseDuration = 0.5f;

    private void Start()
    {
        MoveLeftToRight();
    }

    private void MoveLeftToRight()
    {
        uiElement.DOAnchorPosX(rightPosition, moveDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                DOVirtual.DelayedCall(pauseDuration, () =>
                {
                    uiElement.DOAnchorPosX(leftPosition, moveDuration)
                        .SetEase(Ease.Linear)
                        .OnComplete(() =>
                        {
                            DOVirtual.DelayedCall(pauseDuration, MoveLeftToRight);
                        });
                });
            });
    }
}