using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteTip : MonoBehaviour {

    private bool TypedTip;

    public string TooltipText;

    private void Awake()
    {
        TypedTip = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && TypedTip == false)
        {
            ToolTipType.CreateTooltip(TooltipText);
            TypedTip = true;
        }
    }
}
