using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent zombie;
    public GameObject Target;
    public float health;
    public float enemyhitPower; //D��mana verilecek zarar g�c�
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
    public void hit(float hitPower) //D��mana verilen darbe d��man can�ndan ��kart�l�r
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
            death();  //D��man objesi yok olur.
        }
    }
    void death() 
    {
        mnControl.GetComponent<enemyControl>().updateEnemyCount();
        Destroy(gameObject);
    }
}
