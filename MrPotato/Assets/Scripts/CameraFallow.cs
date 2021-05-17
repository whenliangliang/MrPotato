using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public Transform playerTran;
    public float MaxDistanceX = 1f;
    public float MaxDistanceY = 1f;
    public float xSpeed = 8f;
    public float ySpeed = 8f;
    public Vector2 maxXAndY;       
    public Vector2 minXAndY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        TrackPlayer();
    }
    public void Awake()
    {
        playerTran = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private bool NeedMoveX()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTran.position.x) > MaxDistanceX )
        {
            bMove = true;
        }
        else
            bMove = false;
        return bMove;
    }
    private bool NeedMoveY()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.y - playerTran.position.y) > MaxDistanceY)
        {
            bMove = true;
        }
        else
            bMove = false;
        return bMove;
    }
    private void TrackPlayer()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (NeedMoveX())
        {
            newX = Mathf.Lerp(transform.position.x, playerTran.position.x, xSpeed * Time.deltaTime);
            
        }
        if (NeedMoveY())
        {
            newY = Mathf.Lerp(transform.position.y, playerTran.position.y, ySpeed * Time.deltaTime);
        }
        newX = Mathf.Clamp(newX, minXAndY.x, maxXAndY.x);
        newY = Mathf.Clamp(newY, minXAndY.y, maxXAndY.y);
        transform.position = new Vector3(newX, newY, transform.position.z);
        
    }
}
