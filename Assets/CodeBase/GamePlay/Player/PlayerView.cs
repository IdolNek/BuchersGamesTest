using UnityEngine;

namespace CodeBase.GamePlay.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GameObject _poor;
        [SerializeField] private GameObject _good;
        [SerializeField] private GameObject _perfect;
        [SerializeField] private Animator _animator;

        public void SetPoor()
        {
            _perfect.SetActive(false);
            _good.SetActive(false);
            _poor.SetActive(true);
            _animator.SetBool("IsSad", true);
            _animator.SetBool("IsRich", false);
            _animator.SetBool("IsMiddle", false);
        }

        public void SetGood()
        {
            _good.SetActive(true);
            _poor.SetActive(false);
            _perfect.SetActive(false);
            _animator.SetBool("IsSad", false);
            _animator.SetBool("IsRich", false);
            _animator.SetBool("IsMiddle", true);
        }

        public void SetPerfect()
        {
            _perfect.SetActive(true);
            _good.SetActive(false);
            _poor.SetActive(false);
            _animator.SetBool("IsSad", false);
            _animator.SetBool("IsRich", true);
            _animator.SetBool("IsMiddle", false);
        }

        public void Dance()
        {
            _animator.SetBool("IsSad", false);
            _animator.SetBool("IsRich", false);
            _animator.SetBool("IsMiddle", false);
            _animator.SetBool("Dance", true);
        }
    }
}