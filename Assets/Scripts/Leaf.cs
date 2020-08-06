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
        
        Player.GetComponent<Rigidbody>().constraints = mIsExaming ? RigidbodyConstraints.FreezePosition : RigidbodyConstraints.None;

        // Cursor.lockState = mIsExaming ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
