using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightswitchController : MonoBehaviour {

    public Light lightBulb;
    bool state;

	// Use this for initialization
	void Start () {
        state = false;

        lightBulb.enabled = false;
	}

    private void OnTriggerExit(Collider other)
    {

        ToggleLight();

    }

    void ToggleLight()
    {

        state = !state;

        lightBulb.enabled = state;

    }

}
