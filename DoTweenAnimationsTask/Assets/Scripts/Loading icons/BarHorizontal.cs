using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BarHorizontal : MonoBehaviour {
    
    [SerializeField] private Image[] _collumns; 
    void Start() {
        var delay = 0.04f;
        var step = 0.02f;

        var sequence = DOTween.Sequence();
        for (int i = 0; i < _collumns.Length; i++) {
            sequence.Join(_collumns[i].transform.DOScaleY(4f, 0.7f).SetDelay(delay));
            sequence.Join(_collumns[i].transform.DOScaleY(1f, 0.7f).SetDelay(delay / 2));
            delay += step;
        }
        sequence.SetLoops(-1);
    }
}
