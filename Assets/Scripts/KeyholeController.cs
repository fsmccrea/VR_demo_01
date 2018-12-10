using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class KeyholeController : MonoBehaviour {

    public VRTK_SnapDropZone theZone;
    public GameObject theKey;
    public VRTK.Controllables.ArtificialBased.VRTK_ArtificialRotator theDoorRotator;

    private Animator theAnimator;

	protected virtual void OnEnable()
    {
        theZone = (theZone == null ? GetComponent<VRTK_SnapDropZone>() : theZone);
        theAnimator = GetComponent<Animator>();

        theZone.ObjectSnappedToDropZone += OnSnap;
        theZone.ObjectUnsnappedFromDropZone += OnUnsnap;
    }

    protected virtual void OnSnap(object sender, VRTK.SnapDropZoneEventArgs e)
    {
        print("yuh");
        theAnimator.SetBool("HasKey", true);

        theKey.GetComponent<VRTK_TransformFollow>().enabled = true;
        theDoorRotator.isLocked = false;
    }

    protected virtual void OnUnsnap(object sender, VRTK.SnapDropZoneEventArgs e)
    {
        print("UNyuh");
        theAnimator.SetBool("HasKey", false);

        theKey.GetComponent<VRTK_TransformFollow>().enabled = false;
    }

}
