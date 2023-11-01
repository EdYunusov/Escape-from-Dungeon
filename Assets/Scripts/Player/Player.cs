using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Maze2Dgame
{
    public class Player : SingletonBase<Player>
    {
        [SerializeField] private int m_HP;
        [SerializeField] private Character m_Character;
        [SerializeField] private GameObject m_PlayerCharacterPrefab;
        [SerializeField] private CameraController m_CameraController;
        [SerializeField] private MovementController m_MovementController;


        private void Start()
        {
            m_Character.EventOnDeath.AddListener(OnCharDeaths);
        }

        private void OnCharDeaths()
        {
            m_HP--;

            if (m_HP > 0)
            {
                Respawn();
            }
        }

        private void Respawn()
        {
            var newPlayerCharacter = Instantiate(m_PlayerCharacterPrefab);

            m_Character = newPlayerCharacter.GetComponent<Character>();

            m_CameraController.SetTarget(m_Character.transform);
            m_MovementController.SetTargetCharacter(m_Character);

            m_Character.EventOnDeath.AddListener(OnCharDeaths);
        }
    }
}
