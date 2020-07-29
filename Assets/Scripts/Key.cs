using UnityEngine;

public class Key : MonoBehaviour, IInventoryItem
{
    public string Name 
    {
        get
        {
            return "Key";
        }
    }

    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        // TODO: Add logic what happens when axe is picked up by player
        gameObject.SetActive(false);
    }
}
