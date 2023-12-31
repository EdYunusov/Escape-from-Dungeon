using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGUI : MonoBehaviour
{
    [SerializeField] private Text nameText;

    [SerializeField] private Slider HPSlider;

    [SerializeField] private Image image;

    //[SerializeField] private Text levelText;

    public void SetGUI(Unit unit)
    {
        image.sprite = unit.BattleIconeSprite;
        nameText.text = unit.Nickname;
        HPSlider.maxValue = unit.MaxHP;
        HPSlider.value = unit.CurrentHP;
    }

    public void SetHP(int hp)
    {
        HPSlider.value = hp;
    }
}
