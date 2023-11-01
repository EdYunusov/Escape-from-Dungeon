using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class GraphicsQualitySettings : Settings
{
    private int currentLevelIndex = 0;

    public override bool isMinValue { get => currentLevelIndex == 0; }
    public override bool isMaxValue { get => currentLevelIndex == QualitySettings.names.Length -1; }

    public override void SetNextValue()
    {
        if (isMaxValue == false)
        {
            Debug.Log(currentLevelIndex);
            currentLevelIndex++;
        }
    }

    public override void SetPreviousValue()
    { 
        if (isMinValue == false)
        {
            Debug.Log(currentLevelIndex);
            currentLevelIndex--;
        }
    }

    public override object GetValue()
    {
        return QualitySettings.names[currentLevelIndex];
    }

    public override string GetStringValue()
    {
        return QualitySettings.names[currentLevelIndex];
    }

    public override void Apply()
    {
        QualitySettings.SetQualityLevel(currentLevelIndex);
        Save();
    }

    public override void Load()
    {
        currentLevelIndex = PlayerPrefs.GetInt(title, QualitySettings.names.Length - 1);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(title, currentLevelIndex);
    }
}
