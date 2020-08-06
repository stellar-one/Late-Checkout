using UnityEngine;

public class Leaf : InteractableItemBase {

    private bool mIsExaming = false;
    public GameObject Player;

    public override void OnInteract()
    {
        InteractText = "";

        mIsExaming = !mIsExaming;
        InteractText += mIsExaming ? this.Name : "Examine";

        // TODO: 
        // Camera and player is frozen
        // Camera background is blurred
        // Item is in center view
        // Player can rotate item
        
        Player.GetComponent<CharacterController>().enabled = mIsExaming ? false : true;
        Cursor.lockState = mIsExaming ? CursorLockMode.Locked : CursorLockMode.None;

        if(mIsExaming)
        {
            Player.GetComponent<CharacterController>().enabled = false;

        }
        else
        {
            
        }

    }
}
