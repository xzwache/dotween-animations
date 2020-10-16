using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Cards : MonoBehaviour {
    
    private Button _button;
    [SerializeField] private Transform [] _cards;
    [SerializeField] private Transform _center;

    private Vector3 _defaultCardPosition;
    private Vector3 _cardPosition;
    private int _currentCardNumber;

    private float _spacing = 50f;
    
    // Start is called before the first frame update
    void Start() {

        _button = GetComponent<Button>();
        _button.onClick.AddListener(GetCard);
        _defaultCardPosition = _cards[0].transform.position;

        var positionX = _center.transform.localPosition.x - (_cards.Length / 2 * _spacing);
        _cardPosition = new Vector3(positionX,_center.transform.position.y, _center.transform.position.z);
    }

    private void GetCard() {
        Transform card = _cards[_currentCardNumber];

        var sequence = DOTween.Sequence();

        _cardPosition = new Vector3(_cardPosition.x + _spacing, _cardPosition.y, _cardPosition.z);
        
        sequence.Append(card?.DOLocalMove(_cardPosition, 0.5f).SetDelay(0.2f));
        sequence.Join(card?.DORotate(new Vector3(0.0f, 180f, 0.0f), 0.5f, RotateMode.LocalAxisAdd)
            .OnComplete(() => {
                if (_currentCardNumber >= _cards.Length) {
                    Reset();
                }
            }));
        
        _currentCardNumber++;
    }

    private void Reset() {
        var positionX = _center.transform.localPosition.x - (_cards.Length / 2 * _spacing);
        _cardPosition = new Vector3(positionX,_center.transform.position.y, _center.transform.position.z);
        
        _currentCardNumber = 0;
        for (int i = 0; i < _cards.Length; i++)
            _cards[i].DOLocalMove(_defaultCardPosition, 0.3f).SetDelay(0.5f);
    }
    
}
