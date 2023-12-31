using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private Sprite battleSprite;
    [SerializeField] private Sprite battleIconeSprite;

    public Sprite BattleSprite => battleSprite;
    public GameObject BattleScene => battleScene;
    public Sprite BattleIconeSprite => battleIconeSprite;
    public string Nickname => nickname;
    public int CurrentHP => currentHP;
    public int PhysDamage => physDamage;
    public int MagicDamage => magicDamage;
    public int HealingPower => healingPower;
    public int MaxHP => maxHP;
    public bool isProtected { get; set; }

    private Rigidbody2D m_Rig;

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


    public void UnitDead()
    {
        Destroy(this.gameObject);
    }

    [SerializeField] private UnityEvent m_EventOnDeath;

    protected virtual void OnDeath()
    {
        m_EventOnDeath?.Invoke();
    }
}
