using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    Transform playerTran;
    float MaxDistanceX = 2;
    float MaxDistanceY = 2;
    float xSpeed = 4;
    float ySpeed = 4;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Awake()
    {
        playerTran = transform.Find("Player");
    }
    private bool NeedMoveX()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x = playerTran.position.x))
        {
            bMove = true;
        }
        else
            bMove = false;
        return bMove;
    }
}
