using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class DrakeController : MonoBehaviour 
{

    private Rigidbody rb;
    private Animation an;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, y);
        rb.velocity = movement * 5f;

        if (x!=0 && y!=0) 
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);    
        }

        // If joystick not idle
        if (x!=0 || y!=0)
        {
            an.Play("walking");   
        }
	}
}
