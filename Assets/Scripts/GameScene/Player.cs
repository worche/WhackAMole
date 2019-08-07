using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     Camera camera;
    public GameObject hammer;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);//fare konumundan penceremize doğru ışın yolluyoruz
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) //ışın çarptığı collisionları geri döndürüyor.
            {
                if (hit.transform.tag == "Mole") // mole çarparsa hammer herekete geçiyor. Hammerın değerse mole yere geri gidiyor.
                {
                    
                    Vector3 spawnPos = new Vector3(hit.transform.GetChild(0).position.x,
                        hit.transform.GetChild(0).position.y ,
                        hit.transform.GetChild(0).position.z );

                    Vector3 relativePos = GameObject.FindGameObjectWithTag("Player").transform.position- spawnPos; // oyuncunun konumu ile spawn noktası arasındaki farkı alıp
                   
                    //Bu farkı LookRotation fonksiyonuna veriyoruz
                    Quaternion rotation = Quaternion.LookRotation(relativePos);// oynayan kişi hammerı vuruyormuş gibi hissettirmek için tutma yerlerini oyuncuya dönük hale gelir
                    rotation.eulerAngles = new Vector3(hit.transform.rotation.eulerAngles.x, (180 - rotation.eulerAngles.y)*-1 , (hit.transform.rotation.eulerAngles.z)*-1);
                   //y değerini  kemaraya doğru , x ve z değerlerinide objenin eğikliğine göre değiştriyoruz
                    Instantiate(hammer, spawnPos, rotation);
                   

                }
            }
        }
    }
    
}
