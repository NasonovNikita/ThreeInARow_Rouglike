using Battle.Units;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    private Slider _slider;
    
    [SerializeField]
    private Unit unit;

    [SerializeField]
    private TMP_Text text;

    private void Start()
    {
        if (unit.mana.borderUp == 0)
        {
            Destroy(gameObject);
        }
        
        _slider = GetComponent<Slider>();
        _slider.maxValue = unit.mana.borderUp;
        _slider.minValue = unit.mana.borderDown;
        _slider.value = unit.mana.GetValue();
    }

    private void Update()
    {
        _slider.value = unit.mana.GetValue();
        text.text = $"{_slider.value}/{unit.mana.borderUp}";
    }
}