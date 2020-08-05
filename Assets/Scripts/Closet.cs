using UnityEngine;

public class Closet : InteractableItemBase {

    private bool mIsHiden = false;

    public override void OnInteract()
    {
        InteractText = "";

        mIsHiden = !mIsHiden;
        InteractText += mIsHiden ? "Get out" : "Hide";

        // TODO: Trigger the animation to hide the player in the closet
        Debug.Log(mIsHiden ? "Hiding..." : "Getting out...");
    }
}
