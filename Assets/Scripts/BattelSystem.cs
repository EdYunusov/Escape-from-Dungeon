using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Maze2Dgame;
using UnityEngine.SceneManagement;

public enum BattelState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Won,
    Lose
}

[RequireComponent(typeof(AudioSource))]
public class BattelSystem : MonoBehaviour
{
    public BattelState state;

    [SerializeField] public GameObject playerPrefab;
    [SerializeField] public GameObject enemyPrefab;

    [SerializeField] private Transform playerSpawnGround;
    [SerializeField] private Transform enemySpawnGround;

    [SerializeField] private GameObject battelScene;
    //[SerializeField] private GameObject magicButton;
    [SerializeField] private GameObject levelSound;
    [SerializeField] private AudioSource battleTheme;

    private Unit playerUnit;
    private Unit enemyUnit;

    public BattleGUI playerGUI;
    public BattleGUI enemyGUI;


    private void Start()
    {
        state = BattelState.Start;

        Debug.Log("battle started!");
    }


    public IEnumerator SetupBattle()
    {

        levelSound.SetActive(false);
        battleTheme.Play();

        GameObject playerGO = Instantiate(playerPrefab, playerSpawnGround);
        playerUnit = playerPrefab.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawnGround);
        enemyUnit = enemyPrefab.GetComponent<Unit>();

        playerGUI.SetGUI(playerUnit);
        enemyGUI.SetGUI(enemyUnit);

        playerSpawnGround.GetComponentInChildren<Image>().sprite = playerUnit.BattleSprite;
        enemySpawnGround.GetComponentInChildren<Image>().sprite = enemyUnit.BattleSprite;


        yield return new WaitForSeconds(2f);

        state = BattelState.PlayerTurn;
    }

    IEnumerator PlayerAttack()
    {
        Debug.Log("Attack is succesful!");
        bool isDead = enemyUnit.TakePhysicAttackDamage(playerUnit.PhysDamage);
        enemyGUI.SetHP(enemyUnit.CurrentHP);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattelState.Won;
            Debug.Log("Battle Won!");
            EndBattle();
        }
        else
        {
            state = BattelState.EnemyTurn;
            StartCoroutine(EnemyAttack());
        }
    }

    IEnumerator PlayerMagicAttack()
    {
        Debug.Log("MagicAttack is succesful!");
        bool isDead = enemyUnit.TakeMagicAttakDamage(playerUnit.MagicDamage);
        enemyGUI.SetHP(enemyUnit.CurrentHP);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattelState.Won;
            Debug.Log("Battle Won!");
            EndBattle();
        }
        else
        {
            state = BattelState.EnemyTurn;
            StartCoroutine(EnemyAttack());
        }
    }

    IEnumerator PlayerHeal()
    {
        Debug.Log("Heal is succesful!");
        playerUnit.PlayerHealing(playerUnit.HealingPower);
        playerGUI.SetHP(playerUnit.CurrentHP);

        yield return new WaitForSeconds(2f);

        state = BattelState.EnemyTurn;
        StartCoroutine(EnemyAttack());
    }

    IEnumerator PlayerDefence()
    {
        Debug.Log("HP before attack" + playerUnit.CurrentHP);

        playerUnit.isProtected = true;
        playerUnit.ReduseDamageWhenProtected(enemyUnit.PhysDamage);
        playerGUI.SetHP(playerUnit.CurrentHP);

        yield return new WaitForSeconds(2f);

        playerUnit.isProtected = false;

        state = BattelState.EnemyTurn;
        StartCoroutine(EnemyAttack());
    }

    IEnumerator EnemyAttack()
    {
        Debug.Log("HP after attack" + playerUnit.CurrentHP);

        Debug.Log(enemyUnit.PhysDamage);
        bool isDead =  playerUnit.TakePhysicAttackDamage(playerUnit.PhysDamage);
        playerGUI.SetHP(playerUnit.CurrentHP);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattelState.Lose;
            EndBattle();
        }
        else
        {
            state = BattelState.PlayerTurn;
        }
    }


    private void EndBattle()
    {
        battleTheme.Stop();
        levelSound.SetActive(true);

        if (state == BattelState.Won)
        {
            battelScene.SetActive(false);
            enemyUnit.UnitDead();
        }

        if (state == BattelState.Lose)
        {
            SceneManager.LoadScene(1);
            //обновление инттерфейса и выход из боя/перезагрузка к чекпоинту (?)
        }
    }

    public void OnAttackButton()
    {
        if (state != BattelState.PlayerTurn) return;

        StartCoroutine(PlayerAttack());
    }

    public void OnMagicButton()
    {
        if (state != BattelState.PlayerTurn) return;

        StartCoroutine(PlayerMagicAttack());
    }

    public void OnHealButton()
    {
        if (state != BattelState.PlayerTurn) return;

        StartCoroutine(PlayerHeal());
    }

    public void OnDefenceButton()
    {
        if (state != BattelState.PlayerTurn) return;

        StartCoroutine(PlayerDefence());
    }
}
