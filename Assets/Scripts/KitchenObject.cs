using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    private IKitchenObjectParent kitchenObjectParent;


    private int sliceCount = 0;



    public KitchenObjectSO GetKitchenObjectSO ()
    {
        return kitchenObjectSO;
    }

    public int GetSliceCount()
    {
        return sliceCount;
    }

    public void IncrementSliceCount()
    {
        sliceCount++;
    }

    


    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObjectOnTop();
        }

        this.kitchenObjectParent = kitchenObjectParent;

        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("IKitchenObjectParent already has a kitchen object");
        }
        kitchenObjectParent.setKitchenObject(this);

        transform.parent = kitchenObjectParent.returnSpawnPoint();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent getKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObjectOnTop();
        Destroy(gameObject);
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);

        return kitchenObject;
    }

}
