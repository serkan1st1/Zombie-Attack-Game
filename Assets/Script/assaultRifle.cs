using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assaultRifle : MonoBehaviour
{
    [Header("Settings")]
    public bool shoot;
    float shootFreq1;  //Ateþ etme sýklýðý
    public float shootFreq2;
    public float rangeGun;  //Menzil
    public Camera myCam;
    public float gunStrike;
    [Header("Audios")]
    public AudioSource[] Audios;
    [Header("Effect")]
    public ParticleSystem[] Effects;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)&& shoot && Time.time > shootFreq1)
        {
            startShoot();
            shootFreq1 = Time.time + shootFreq2;
        }
    }

    void startShoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(myCam.transform.position,myCam.transform.forward,out hit,rangeGun))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                Effects[0].Play();
                Audios[0].Play();
                Instantiate(Effects[2], hit.point, Quaternion.LookRotation(hit.normal));
                hit.transform.gameObject.GetComponent<Enemy>().hit(gunStrike); //Düþmana verilen darbe 
               
            }
            else
            {
                Effects[0].Play();
                Audios[0].Play();
                Instantiate(Effects[1], hit.point, Quaternion.LookRotation(hit.normal));
                
            }
            
        }
     


    }
}
