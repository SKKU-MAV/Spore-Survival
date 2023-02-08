using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobRandomSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> gameObjects;

    public int current_bear_count = 0;
    public int current_slime_count = 0;

    [SerializeField]
    private int max_bear_count = 1;
    [SerializeField]
    private int max_slime_count = 5;



    private void Update()
    {
        foreach(GameObject gb in gameObjects)
        {
            if(gb.name == "LastBeaver")
            {
                if(current_bear_count < max_bear_count)
                {
                    StartCoroutine(WaitAndInstantiate(gb));
                    current_bear_count++;
                }
            }

            else if(gb.name == "Slime")
            {
                if (current_slime_count < max_slime_count)
                {
                    StartCoroutine(WaitAndInstantiate(gb));
                    current_slime_count++;
                }
            }
        }
        
    }

    private IEnumerator WaitAndInstantiate(GameObject gb)
    {
        Instantiate(gb, transform.position, transform.rotation);
        yield return new WaitForSeconds(2.0f);
    }
}




