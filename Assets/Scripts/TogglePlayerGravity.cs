using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlayerGravity : DefaultTrackableEventHandler
{
    public GameObject player;

    protected override void OnTrackingFound()
    {
        player.GetComponent<Rigidbody>().useGravity = true;
    }

    protected override void OnTrackingLost()
    {
        player.GetComponent<Rigidbody>().useGravity = false;
    }
}
