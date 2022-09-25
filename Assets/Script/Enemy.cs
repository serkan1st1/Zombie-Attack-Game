using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent zombie;
    public GameObject Target;
    public float health;
    public float enemyhitPower; //Düþmana verilecek zarar gücü
    GameObject mnControl;
   
    void Start()
    {
        mnControl = GameObject.FindWithTag("mainControl");
        zombie = GetComponent<NavMeshAgent>();
       
    }
    public void setGoal(GameObject myObject)
    {
        Target = myObject;
    }

    
    void Update()
    {
        zombie.SetDestination(Target.transform.position);
    }
    public void hit(float hitPower) //Düþmana verilen darbe düþman canýndan çýkartýlýr
    {
        health -= hitPower;
        if(health<=0)
        {
            death();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("protect"))
        {
            
            mnControl.GetComponent<enemyControl>().Attack(enemyhitPower);
            death();  //Düþman objesi yok olur.
        }
    }
    void death() 
    {
        mnControl.GetComponent<enemyControl>().updateEnemyCount();
        Destroy(gameObject);
    }
}
