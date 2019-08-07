using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)
        {
        if (other.tag == "Mole") 
            transform.parent.GetComponent<Hammer>().CollisionDetected(other); //hammer ın vuruş alanına değen objeyi
         
    }
}
