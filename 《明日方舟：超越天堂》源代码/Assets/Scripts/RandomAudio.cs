using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 0f;
    public Component[] audio;
    void Start()
    {
        audio = this.gameObject.GetComponents(typeof(AudioSource));
        
    }

    // Update is called once per frame
    void Update()
    {
       
        time += Time.time;
        
        //OnMouseOver();

    }

    public void OnMouseOver()
    {
        //if (Input.GetMouseButtonDown(0))
        {
            
            for (int i = 0; i < audio.Length; i++)
            {
                AudioSource ad = (AudioSource)audio[i];
                ad.Stop();
            }
            
            Debug.Log("nbnbnbnbnb");
            if (time % 3 >= 0 && time % 3 < 1)
            {

                AudioSource adc = (AudioSource)audio[0];
                adc.Play();

            }

            else if (time % 3 >= 1 && time % 3 < 2)
            {

                AudioSource adc = (AudioSource)audio[1];
                adc.Play();
            }

            else
            {

                AudioSource adc = (AudioSource)audio[2];
                adc.Play();
            }
        }
        
    }
}
