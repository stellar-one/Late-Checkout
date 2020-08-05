// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.EventSystems;

// public class PlayerController : MonoBehaviour
// {
//     #region Private Members
//     private Animator _animator;
//     private CharacterController _characterController;
//     private InventoryItemBase mCurrentItem = null;
//     Vector3 velocity;

//     #endregion

//     #region Public Members
//     public float speed = 6.0f;
//     public float jumpHeight = 2.0f;
//     public float gravity = -9.81f;
//     GameObject target;
//     GameObject elevator;
//     public Inventory Inventory;
//     public GameObject Hand;
//     public HUD Hud;

//     #endregion

//     void Start()
//     {
//         _animator = GetComponent<Animator>();
//         _characterController = GetComponent<CharacterController>();

//         Inventory.ItemUsed += Inventory_ItemUsed;
//         Inventory.ItemRemoved += Inventory_ItemRemoved;
//     }

//     #region Inventory

//     private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
//     {
//         InventoryItemBase item = e.Item;

//         GameObject goItem = (item as MonoBehaviour).gameObject;
//         goItem.SetActive(true);
//         goItem.transform.parent = null;

//         if (item == mCurrentItem)
//             mCurrentItem = null;

//     }

//     private void SetItemActive(InventoryItemBase item, bool active)
//     {
//         GameObject currentItem = (item as MonoBehaviour).gameObject;
//         currentItem.SetActive(active);
//         currentItem.transform.parent = active ? Hand.transform : null;
//     }


//     private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
//     {
//         if (e.Item.ItemType != EItemType.Consumable)
//         {
//             // If the player carries an item, un-use it (remove from player's hand)
//             if (mCurrentItem != null)
//             {
//                 SetItemActive(mCurrentItem, false);
//             }

//             InventoryItemBase item = e.Item;

//             // Use item (put it to hand of the player)
//             SetItemActive(item, true);

//             mCurrentItem = e.Item;
//         }

//     }

//     public void DropAndDestroyCurrentItem()
//     {
//         GameObject goItem = (mCurrentItem as MonoBehaviour).gameObject;

//         Inventory.RemoveItem(mCurrentItem);

//         Destroy(goItem);

//         mCurrentItem = null;
//     }

//     #endregion

//     public bool CarriesItem(string itemName)
//     {
//         if (mCurrentItem == null)
//             return false;

//         return (mCurrentItem.Name == itemName);
//     }

//     public InventoryItemBase GetCurrentItem()
//     {
//         return mCurrentItem;
//     }

//     void Update()
//     {
//         // Interact with the item
//         if (mInteractItem != null && Input.GetKeyDown(KeyCode.F))
//         {
//             // Interact animation
//             mInteractItem.OnInteractAnimation(_animator);
//         }

//         // Execute action with item
//         if (mCurrentItem != null && Input.GetMouseButtonDown(0))
//         {
//             // Dont execute click if mouse pointer is over uGUI element
//             if (!EventSystem.current.IsPointerOverGameObject())
//             {
//                 // TODO: Logic which action to execute has to come from the particular item
//                 _animator.SetTrigger("attack_1");
//             }
//         }
        
//         if(_characterController.isGrounded && velocity.y < 0)
//         {
//             velocity.y = -2f;
//         }

//         float h = Input.GetAxis("Horizontal");
//         float v = Input.GetAxis("Vertical");

//         Vector3 move = transform.right * h + transform.forward * v;

//         _characterController.Move(move * speed * Time.deltaTime);

//         target = Camera.main.GetComponent<MouseLook>().RaycastedObj;

//         if (Input.GetKeyDown("e")) // interact key
//         {
//             if (target.CompareTag("Elevator Buttons"))
//             {
//                 elevator = target;
//                 target.GetComponent<Elevator>().CallElevator(target.GetComponent<Elevator>().button);
//             }
            
//             if (target.name == "Basement")
//             {
//                 elevator.GetComponent<Elevator>().CloseElevatorDoors();
//                 elevator.GetComponent<Elevator>().CallElevator(0);
//             }
//             if (target.name == "Main Floor")
//             {
//                 elevator.GetComponent<Elevator>().CloseElevatorDoors();
//                 elevator.GetComponent<Elevator>().CallElevator(1);
//             }
//             if (target.name == "First Floor")
//             {
//                 elevator.GetComponent<Elevator>().CloseElevatorDoors();
//                 elevator.GetComponent<Elevator>().CallElevator(2);
//             }
//             if (target.name == "Roof")
//             {
//                 elevator.GetComponent<Elevator>().CloseElevatorDoors();
//                 elevator.GetComponent<Elevator>().CallElevator(3);
//             }

//             if (target.CompareTag("Openable") && !target.GetComponent<Animator>().GetBool("Open"))
//             {
//                 Open();
//             }
//             else if (target.CompareTag("Openable") && target.GetComponent<Animator>().GetBool("Open"))
//             {
//                 Close();
//             }

//             // if (target.CompareTag("Item"))
//             // {
//             //     IInventoryItem item = target.GetComponent<IInventoryItem>();
//             //     if(item != null)
//             //     {
//             //         inventory.AddItem(item);
//             //     }
//             // }

//             if (target.CompareTag("Hide"))
//             {
//                 Debug.Log("Hiding");
//             }

//             if (target.CompareTag("Examine"))
//             {
//                 Debug.Log("Examining " + target.name);
//             }
            
//         }

//         if(Input.GetButtonDown("Jump") && _characterController.isGrounded)
//         {
//             velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
//         }

//         if (Input.GetKeyDown(KeyCode.LeftShift) && _characterController.isGrounded)
//         {
//             speed = 8f;
//         }
//         else if (Input.GetKeyUp(KeyCode.LeftShift) && _characterController.isGrounded)
//         {
//             speed = 6f;
//         }

//         if(Input.GetKeyDown(KeyCode.LeftControl) && _characterController.isGrounded)
//         {
//             transform.localScale = new Vector3(1f, .5f, 1f);
//             speed = 4f;
//         }
//         else if(Input.GetKeyUp(KeyCode.LeftControl) && _characterController.isGrounded)
//         {
//             transform.localScale = new Vector3(1f, 1f, 1f);
//             speed = 6f;
//         }

//         velocity.y += gravity * Time.deltaTime;

//         _characterController.Move(velocity * Time.deltaTime);
//     }

//     public void InteractWithItem()
//     {
//         if (mInteractItem != null)
//         {
//             mInteractItem.OnInteract();

//             if (mInteractItem is InventoryItemBase)
//             {
//                 InventoryItemBase inventoryItem = mInteractItem as InventoryItemBase;
//                 Inventory.AddItem(inventoryItem);
//                 inventoryItem.OnPickup();

//                 if (inventoryItem.UseItemAfterPickup)
//                 {
//                     Inventory.UseItem(inventoryItem);
//                 }
//                 Hud.CloseMessagePanel();
//                 mInteractItem = null;
//             }
//             //else
//             //{
//             //    if (mInteractItem.ContinueInteract())
//             //    {
//             //        Hud.OpenMessagePanel(mInteractItem);
//             //    }
//             //    else
//             //    {
//             //        Hud.CloseMessagePanel();
//             //        mInteractItem = null;
//             //    }
//             //}
//         }
//     }

//     private InteractableItemBase mInteractItem = null;

//     private void OnTriggerEnter(Collider other)
//     {
//         TryInteraction(other);
//     }

//     private void TryInteraction(Collider other)
//     {
//         InteractableItemBase item = other.GetComponent<InteractableItemBase>();

//         if (item != null)
//         {
//             if (item.CanInteract(other))
//             {
//                 mInteractItem = item;

//                 Hud.OpenMessagePanel(mInteractItem);
//             }
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         InteractableItemBase item = other.GetComponent<InteractableItemBase>();
//         if (item != null)
//         {
//             Hud.CloseMessagePanel();
//             mInteractItem = null;
//         }
//     }

//     void Open()
//     {
//         target.GetComponent<Animator>().SetBool("Open", true);
//     }

//     void Close()
//     {
//         target.GetComponent<Animator>().SetBool("Open", false);
//     }
// }