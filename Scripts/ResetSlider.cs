using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetSlider : MonoBehaviour {

    public Slider w6Slider, w10Slider, w20Slider;
    public InputField w6Input, w10Input, w20Input;


    public void ResetSliders(){
        if(w6Slider!=null && w10Slider!=null && w20Slider !=null){
            w6Slider.value = 0;
            w10Slider.value = 0;
            w20Slider.value = 0;

            //Reset Input Field
            w6Input.text = "0";
            w10Input.text = "0";
            w20Input.text = "0";
        }
    }
}
