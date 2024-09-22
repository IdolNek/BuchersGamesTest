using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.GamePlay.Player
{
    public class BarView : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        [SerializeField] private TMP_Text _text;
        
        public void SetFillProgress(float progress) => _bar.fillAmount = progress;

        public void SetPoorText()
        {
            _bar.gameObject.SetActive(true);
            _text.gameObject.SetActive(true);
            _text.text = "Бедный";
        }
        public void SetGoodText()
        {
            _bar.gameObject.SetActive(true);
            _text.gameObject.SetActive(true);
            _text.text = "Состоятельный";
        }
        
        public void SetPerfectText()
        {
            _text.gameObject.SetActive(false);
            _bar.gameObject.SetActive(false);
        }
    }
}