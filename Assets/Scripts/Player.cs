using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;
    [SerializeField] private KitchenChaosGameManager gameManager;
    public static BaseCounter selectedCounter;

    [SerializeField] Transform spawnPoint;
    public KitchenObject kitchenObjectOnTop;

    private bool isMoving;

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public event EventHandler OnKitchenObjectPickedUp;
    public event EventHandler <OnMoveSatusChangedEventArgs> OnMoveSatusChanged;

    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }

    public class OnMoveSatusChangedEventArgs : EventArgs
    {
        public bool moveStatus;
    }

    private void Start()
    {
        //bu event her e'ye basýldýgýnda ateþlenir
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction;
    }

    private void GameInput_OnInteractAlternateAction(object sender, System.EventArgs e)
    {
        if (!gameManager.IsGamePlaying())
            return;

        if (selectedCounter != null)
        {
            selectedCounter.InteractAlternate(this);
        }
    }

    //bu fonksiyon Interaksiyonlarý halleder
    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (!gameManager.IsGamePlaying())
            return;

        if (selectedCounter!=null)
        {
            selectedCounter.Interact(this);
        }
    }




    private void Update()
    {
        HandleMovement();
        HandleInteractions();
       
    }

     
    private void HandleMovement()
    {
        //moveVector ayarlama
        Vector2 inputVector = new Vector2();
        inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveVector = new Vector3(0, 0, 0);
        moveVector.x = inputVector.x;
        moveVector.z = inputVector.y;

        //rotasyon
        float rotateSpeed = 12f;
        transform.forward = Vector3.Slerp(transform.forward, moveVector, Time.deltaTime * rotateSpeed);

        //raycastle önde obje olma kontrolü
        float playerHeight = 2f;
        float playerRadius = 0.7f;
        float moveDistance = Time.deltaTime * moveSpeed;

        
        
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveVector, moveDistance);

       
        

        //hareket

        //eðer güncel yönde hareket edebiliyosan hareket et
        if (canMove)
        {
            transform.position = transform.position + moveVector * Time.deltaTime * moveSpeed;
        }


        if (!canMove)
        {
            Vector3 xCheck = moveVector;
            xCheck.z = 0f;
            //xte hareket mümkünse et
            if (!Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, xCheck, moveDistance))
            {
                transform.position = transform.position + xCheck * Time.deltaTime * moveSpeed;
            }

            Vector3 zCheck = moveVector;
            zCheck.x = 0;
            //zde hareket mümkünse et
            if (!Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, zCheck, moveDistance))
            {
                transform.position = transform.position + zCheck * Time.deltaTime * moveSpeed;
            }
        }

         

        
    }

    Vector3 lastMoveVector;
    
    private void HandleInteractions()
    {
        //moveVector ayarlama
        Vector2 inputVector = new Vector2();
        inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveVector = new Vector3(0, 0, 0);
        moveVector.x = inputVector.x;
        moveVector.z = inputVector.y;


        //son baktýgýmýz yeri kaydetme
        if(moveVector!=Vector3.zero)
        {
            lastMoveVector = moveVector;
        }

        RaycastHit raycastHit;
        float maxDistance = 2f;

        

        //bir þeye vuruyosa true olur, vurduðu þeyi raycastHitte depolar
        if (Physics.Raycast(transform.position, lastMoveVector, out raycastHit, maxDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if(baseCounter != selectedCounter)
                {
                    selectedCounter = baseCounter;
                    OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { selectedCounter = selectedCounter });
                }             
            }
            else
            {
                selectedCounter = null;
                OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { selectedCounter = selectedCounter });
            }
        }
        else
        {
            selectedCounter = null;
            OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { selectedCounter = selectedCounter });
        }    
    }


    public bool IsMoving()
    {
        Vector2 inputVector = new Vector2();
        inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveVector = new Vector3(0, 0, 0);
        moveVector.x = inputVector.x;
        moveVector.z = inputVector.y;

        //this bool is for IsMoving() method
        if (moveVector == Vector3.zero)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        return isMoving;
    }

    public Transform returnSpawnPoint()
    {
        return spawnPoint;
    }

    public void setKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObjectOnTop = kitchenObject;
        OnKitchenObjectPickedUp?.Invoke(this, EventArgs.Empty);
    }

    public KitchenObject getKitchenObject()
    {
        return kitchenObjectOnTop;
    }

    public void ClearKitchenObjectOnTop()
    {
        kitchenObjectOnTop = null;
    }

    public bool HasKitchenObject()
    {
        return (kitchenObjectOnTop != null);
    }
}
