
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Camera fpsCam;

    public float reach = 5;

    bool holding = false;
    public GameObject hand;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && holding == false)
        {
            Grab(); 
            
            Debug.Log(holding);
            
        } 
        else if (Input.GetButtonDown("Fire2") && holding == true)
        {
            Drop();
            
            Debug.Log(holding);
		}
       
    }


    void Grab()
    {
        RaycastHit take;
        
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out take, reach))
        {
            Debug.Log("gotit");
            Item item = take.transform.GetComponent<Item>();// get the conponent = the transform of the ray when it hits sonthing            
            item.MoveToHand();
            holding = true;
		}
	}
    
    void Drop()
    {
        RaycastHit drop;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out drop, reach))
        {
           Item item = hand.GetComponentInChildren<Item>();
           item.MoveToEnviroment(drop.point,  Quaternion.LookRotation(drop.normal));
           holding = false;
        }

	}

    
}
