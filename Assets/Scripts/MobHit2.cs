using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHit2 : MonoBehaviour
{
    [SerializeField]
    private int hp = 100;

    bool isHit = false;


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Weapon")){

            if(!isHit){

                hp -= 20;
                
            }

            
            
            Debug.Log($"Hp : {hp}");

            if(hp <= 0){
                Destroy(gameObject);
            }
            
            isHit = true;

        }
        
    }

    private void OnTriggerExit(Collider other) {
        isHit = false;
        
    }

    


    
}