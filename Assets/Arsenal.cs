using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arsenal : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons = new List<Weapon>(); // TODO automatically load weapons from resources

    private List<Pool> pools = new List<Pool>();

    private int currentWeapon = 0;

    private void Start()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            pools.Add(new Pool());
        }
    }

    public Weapon GetCurrentWeapon()
    {
        return weapons[currentWeapon];
    }
}
