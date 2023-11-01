using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionTypeSelect
{
    Attack,
    Magic,
    Defence,
    Heal
}


public class ActionType : ScriptableObject
{
    [SerializeField] protected string title;
    public string Title => title;

    //Реализовать тип действия. Нужно: название, атака физическая, магическая, исцеление, защита.
}

