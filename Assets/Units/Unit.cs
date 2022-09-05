using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = StringManager.GAME_RESOURCES_MENU + "Unit")]
public class Unit : ScriptableObject
{
    [SerializeField] private GameObject basePrefab;

    [SerializeField] private Ability primaryAbility;

    [SerializeField] private Ability secondaryAbility;
}