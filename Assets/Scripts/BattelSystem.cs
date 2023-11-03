using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

public class BattelSystem : MonoBehaviour
{
    public BattelState state;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform playerSpawnGround;
    [SerializeField] private Transform enemySpawnGround;

    [SerializeField] private GameObject battelScene;

    private Unit playerUnit;
    private Unit enemyUnit;

    public BattleGUI playerGUI;
    public BattleGUI enemyGUI;

    private PlayerController playerController;


    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        state = BattelState.Start;
        StartCoroutine(SetupBattle());


    }

    private void PlayerTurn()
    {
        //поместить тут ход игрока
    }

    IEnumerator SetupBattle()
    {
        playerController.enabled = false;

        GameObject playerGO = Instantiate(playerPrefab, playerSpawnGround);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawnGround);
        enemyUnit = enemyGO.GetComponent<Unit>();

        playerGUI.SetGUI(playerUnit);
        enemyGUI.SetGUI(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattelState.PlayerTurn;
        PlayerTurn();
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
            PlayerTurn();
        }
    }


    private void EndBattle()
    {
        if (state == BattelState.Won)
        {
            battelScene.SetActive(false);
            playerController.enabled = true;
        }

        if (state == BattelState.Lose)
        {
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
