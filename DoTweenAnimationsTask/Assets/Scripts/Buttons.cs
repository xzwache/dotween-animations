using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Buttons : MonoBehaviour {

    [SerializeField] private Button _infoButton;
    [SerializeField] private Button _plusButton;
    [SerializeField] private Button _upButton;
    // Start is called before the first frame update
    void Start()
    {
        _infoButton.onClick.AddListener(AnimateInfoButton);   
        _plusButton.onClick.AddListener(AnimatePlusButton);   
        _upButton.onClick.AddListener(AnimateUpArrowButton);
    }

    private void AnimateInfoButton() {
        var sequence = DOTween.Sequence();
        sequence.Append(_infoButton.transform.DOScale(Vector3.one * 1.5f, 0.5f));
        sequence.Join(_infoButton.image.DOColor(new Color(255, 255, 255, 0), 0.5f));
    }

    private void AnimatePlusButton() {
        var sequence = DOTween.Sequence();
        sequence.Append(_plusButton.transform.DOScale(Vector3.one * 0.75f, 0.15f));
        sequence.Append(_plusButton.transform.DOScale(Vector3.one, 0.15f));
    }

    private void AnimateUpArrowButton() {
        var sequence = DOTween.Sequence();
        sequence.Append(_upButton.transform.DOScale(Vector3.one * 0.75f, 0.15f));
        sequence.Append(_upButton.transform.DOLocalMoveY(75, 0.25f));
        sequence.Join(_upButton.transform.DOScale(Vector3.one, 0.15f));
        sequence.Join(_upButton.image.DOColor(new Color(255, 255, 255, 0), 0.15f).SetDelay(0.05f));
    }
}
