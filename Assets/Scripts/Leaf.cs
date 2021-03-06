﻿using UnityEngine;

public class Leaf : InteractableItemBase {

    private bool mIsExaming = false;
    public GameObject PC;

    public override void OnInteract()
    {
        InteractText = "";

        mIsExaming = !mIsExaming;
        InteractText += mIsExaming ? this.Name : "Examine";

        // TODO: 
        // Pause player movement
        // Camera background is blurred
        // Item is in center view
        // Player can rotate item
        
        if(mIsExaming)
        {
            PC.GetComponent<PlayerController>().IsControlEnabled = false;
            Camera.main.GetComponent<MouseLook>().DisableMouse();
        }
        else
        {
            PC.GetComponent<PlayerController>().IsControlEnabled = true;
            Camera.main.GetComponent<MouseLook>().EnableMouse();
        }

    }
}
