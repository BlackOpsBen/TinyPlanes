using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugDisplayCaptureCounters : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> counters;

    [SerializeField] private Capturable capturable;

    private void Update()
    {
        counters[0].text = capturable.GetCounter(0).ToString();
        counters[1].text = capturable.GetCounter(1).ToString();
        counters[2].text = capturable.GetCounter(2).ToString();
        counters[3].text = capturable.GetCounter(3).ToString();
    }
}
