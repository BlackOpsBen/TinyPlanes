using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class FactionManager : MonoBehaviour
{
    public static FactionManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    [SerializeField] private List<Faction> factions = new List<Faction>();

    public int GetNumFactions()
    {
        return factions.Count;
    }

    public Faction GetFaction(int index)
    {
        return factions[index];
    }

    public int GetFactionIndex(string tag)
    {
        for (int i = 0; i < factions.Count; i++)
        {
            if (factions[i].name == tag)
            {
                return i;
            }
        }

        Debug.LogError("Invalid Tag provided to GetFactionIndex");
        return -1;
    }
}
