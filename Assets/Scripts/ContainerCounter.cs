using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObject;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (!player.HasKitchenObject())
            {//üstünde biþey yok oyuncuda biþey yok
                KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

                OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                //üstünde biþey yok oyuncuda biþey var
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                //üstünde biþey var oyuncuda biþey yok
                GetKitchenObject().SetKitchenObjectParent(player);
            }
            else
            {
                //üstünde biþey var oyuncuda biþey var
            }
        }
        
        

    }
}
