using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetSlider : MonoBehaviour {

    public Slider w6Slider, w10Slider, w20Slider;


    public void ResetSliders(){
        if(w6Slider!=null && w10Slider!=null && w20Slider !=null){
            w6Slider.value = 0;
            w10Slider.value = 0;
            w20Slider.value = 0;
        }
    }
}
