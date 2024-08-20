using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : MonoBehaviour
{
    public const float Damage = 5;
    private float lastTouch;
    private float cooltime = 0.6f;
    private bool isTouch;
    private AudioSource audioSource;
    [SerializeField] private AudioClip meteorSE;

    [SerializeField] private GameObject vfx;

    private void Start() 
    {
        isTouch = false;
        lastTouch = 0;
        vfx.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        //audioSource.PlayOneShot(meteorSE);
    }
    public void MeteoEnd()
    {
        Destroy(this.gameObject);
    }

    public void MeteoBurn()
    {
        vfx.SetActive(true);
        for(int i = 0; i < 2; i++)
        {
            var obj = this.transform.GetChild(i);
            obj.gameObject.SetActive(false);
        }
        lastTouch = Time.time;
        isTouch = true;
    }

    private void Update() 
    {
        if(Time.time - lastTouch >= cooltime && isTouch)    
        {
            MeteoEnd();
        }
    }
}
