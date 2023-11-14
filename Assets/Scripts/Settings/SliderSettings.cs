using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderSettings : MonoBehaviour
{
    private Slider slider;
    private float currentValue;
    [SerializeField] private float step;
    [SerializeField] private UISettingsButton settingButton;


    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        currentValue = slider.value;
        slider.value = float.Parse(settingButton.Settings.GetStringValue()) / step;
        slider.onValueChanged.AddListener(OnChangeValueSettings);
    }

    public void OnChangeValueSettings(float sliderValue)
    {
        if (currentValue > sliderValue)
        {
            settingButton.SetPreviousValueSettings();
        }
        else if (currentValue < sliderValue)
        {
            settingButton.SetNextValueSettings();
        }

        currentValue = slider.value;
    }
}
