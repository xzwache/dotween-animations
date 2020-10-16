using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CircleBar : MonoBehaviour
{
    [SerializeField] private Image[] _collumns; 
    void Start()
    {
        for (int i = 0; i < _collumns.Length; i++) {
            _collumns[i].color = Color.gray;
        }

        var sequence = DOTween.Sequence();
        for (int i = 0; i < _collumns.Length; i++) {
            sequence.Append(_collumns[i].DOColor(Color.white, 0.15f));
            sequence.Join(_collumns[i].DOColor(Color.gray, 0.15f).SetDelay(0.2f));
        }
        sequence.SetLoops(-1);   
    }
}
