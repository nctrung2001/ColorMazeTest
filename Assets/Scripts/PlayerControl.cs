using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Vector3 hitPos;
    private Vector3 target;
    int layerMask = 3;

    private bool isRunning = false;

    [SerializeField] private GameObject swipeManager;

    private void Awake()
    {
        swipeManager = GameObject.FindGameObjectWithTag("SwipeManager");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CheckCube")
        {
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        // if(transform.position == target)
        // {
        //     isRunning = false;
        // }
        // else isRunning = true;
 
        if(swipeManager.GetComponent<SwipeDetector>().leftCheck)
        {
            RCLeft();
        }
        else if(swipeManager.GetComponent<SwipeDetector>().rightCheck)
        {
            RCRight();
        }
        else if(swipeManager.GetComponent<SwipeDetector>().upCheck)
        {
            RCForward();
        }
        else if(swipeManager.GetComponent<SwipeDetector>().downCheck)
        {
            RCBack();
        }
    }

    void RCLeft()
    {
        RaycastHit hit;
        if(!isRunning)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity, layerMask))
        {
            hitPos = hit.collider.gameObject.transform.position;
        }

        target = new Vector3(hitPos.x +1f, 1f, hitPos.z);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(hitPos.x +1f, 1f, hitPos.z), moveSpeed*Time.deltaTime);
        if(transform.position == target)
        {
            isRunning = false;
            target = Vector3.zero;
        }
        else isRunning = true;
    }

    void RCRight()
    {
        RaycastHit hit;
        if(!isRunning)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity, layerMask))
        {
            hitPos = hit.collider.gameObject.transform.position;
        }
        
        target = new Vector3(hitPos.x -1f, 1f, hitPos.z);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(hitPos.x -1f, 1f, hitPos.z), moveSpeed*Time.deltaTime);
        if(transform.position == target)
        {
            isRunning = false;
            target = Vector3.zero;
        }
        else isRunning = true;

    }

    void RCForward()
    {
        RaycastHit hit;
        if(!isRunning)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            hitPos = hit.collider.gameObject.transform.position;
        }    
        
        target = new Vector3(hitPos.x, 1f, hitPos.z -1f);
        transform.position = Vector3.MoveTowards(transform.position, target = new Vector3(hitPos.x, 1f, hitPos.z -1f), moveSpeed*Time.deltaTime);
        if(transform.position == target)
        {
            isRunning = false;
            target = Vector3.zero;
        }
        else isRunning = true;

    }

    void RCBack()
    {
        RaycastHit hit;
        if(!isRunning)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, Mathf.Infinity, layerMask))
        {
            hitPos = hit.collider.gameObject.transform.position;
        }
        
        target = new Vector3(hitPos.x, 1f, hitPos.z +1f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(hitPos.x, 1f, hitPos.z +1f), moveSpeed*Time.deltaTime);
        if(transform.position == target)
        {
            isRunning = false;
            target = Vector3.zero;
        }
        else isRunning = true;
    }

    
}
