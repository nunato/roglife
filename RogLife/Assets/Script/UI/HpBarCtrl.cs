using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarCtrl : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private Text _hpText;

    private int _hp = 0;

    void Update()
    {
        //_hp += 1;
        if( _hp > 100 ){
            _hp = 0;
        }

        _slider.value = _hp;
        _hpText.text = _hp + "/" + _slider.maxValue;
    }
}
