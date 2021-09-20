using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Superiority : MonoBehaviour
{
    [Tooltip("1 is default")]
    [SerializeField] float capturePointFactor = 1f;
}
