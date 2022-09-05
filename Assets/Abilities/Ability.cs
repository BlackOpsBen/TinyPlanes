using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = StringManager.GAME_RESOURCES_MENU + "Ability")]
public class Ability : ScriptableObject
{
    //[Tooltip("Prefab that contains the ability component.")]
    [SerializeField] private GameObject abilityPrefab;

    //public IAbility GetAbilityComponent()
    //{
    //    return abilityPrefab.GetComponent<IAbility>();
    //}
}
