﻿
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject hand;
    
    
    public void MoveToHand()
    {
       this.transform.position = hand.transform.position;
       this.transform.parent = hand.transform;
       this.transform.rotation = hand.transform.rotation;
       
	}
   
        
	
    public void MoveToEnviroment(Vector3 dropPoint, Quaternion oriantation)
    {
        this.transform.position = dropPoint;
        this.transform.parent = null;
        this.transform.rotation = hand.transform.rotation;
	    
    }


}
