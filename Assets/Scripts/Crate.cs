using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : InteractableItemBase {

    private bool mIsOpen = false;

    public override void OnInteract()
    {
        InteractText = "";

        mIsOpen = !mIsOpen;
        InteractText += mIsOpen ? "Close" : "Open";

        GetComponent<Animator>().SetBool("open", mIsOpen);
    }
}
