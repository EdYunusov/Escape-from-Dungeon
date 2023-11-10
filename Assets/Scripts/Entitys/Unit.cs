using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Unit : MonoBehaviour
{
    [SerializeField] private string nickname;
    [SerializeField] private int maxHP;
    [SerializeField] private int currentHP;
    [SerializeField] private int physDamage;
    [SerializeField] private int magicDamage;
    [SerializeField] private int healingPower;

    [SerializeField] private GameObject battleScene;

    public GameObject BattleScene => battleScene;

    private Rigidbody2D m_Rig;
    public bool isProtected { get; set; }

    public string Nickname => nickname;
    public int CurrentHP => currentHP;
    public int PhysDamage => physDamage;
    public int MagicDamage => magicDamage;
    public int HealingPower => healingPower;
    public int MaxHP => maxHP;


    public bool TakePhysicAttackDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP < 0)
        {
            OnDeath();
            return true;
        }

        else
            return false;
    }

    public bool TakeMagicAttakDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP < 0)
        {
            OnDeath();
            return true;
        }

        else
            return false;
    }

    public void PlayerHealing(int heal)
    {
        if (currentHP < maxHP)
        {
            currentHP += heal;
        }
    }

    public int ReduseDamageWhenProtected(int dmg)
    {
        if (isProtected) physDamage = dmg / 2;
        return physDamage;
    }

    public void PlayerEscape()
    {
        battleScene.SetActive(false);
    }

    [SerializeField] private UnityEvent m_EventOnDeath;
    

    protected virtual void OnDeath()
    {
        SceneManager.LoadScene(1);
        m_EventOnDeath?.Invoke();
    }
}
