using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class FlashlightController : MonoBehaviour {

    public VRTK.VRTK_InteractableObject linkedObject;

    Light lightBulb;

    bool flashlightLit = false;

    protected virtual void OnEnable()
    {
        lightBulb = GetComponentInChildren<Light>();
        flashlightLit = false;
        ToggleFlashlight(flashlightLit);

        linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed += InteractableObjectUsed;
         //   linkedObject.InteractableObjectUnused += InteractableObjectUnused;
        }
    }

    protected virtual void OnDisable()
    {
        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
         //   linkedObject.InteractableObjectUnused -= InteractableObjectUnused;
        }
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        flashlightLit = !flashlightLit;
        ToggleFlashlight(flashlightLit);
    }

    //protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    //{
    //    flashlightLit = false;
    //    ToggleFlashlight(flashlightLit);

    //}

    //// Use this for initialization
    //void Start () {

    //       lightBulb = GetComponentInChildren<Light>();
    //       flashlightLit = false;

    //       ToggleFlashlight(flashlightLit);

    //}

    //// Update is called once per frame
    //void Update () {

    //       if (buttonStuff.buttonTwoPressed)
    //       {
    //           flashlightLit = !flashlightLit;
    //           ToggleFlashlight(flashlightLit);
    //       }
    //}

       void ToggleFlashlight(bool state)
       {
           lightBulb.enabled = state;
       }
}
