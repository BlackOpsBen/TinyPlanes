using UnityEngine;

[CreateAssetMenu(menuName = "Game Resources/Faction")]
public class Faction : ScriptableObject
{
    [SerializeField] private Color color = Color.white;
}
