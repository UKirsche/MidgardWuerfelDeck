using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResetDSAUI : MonoBehaviour {

    public Dropdown mutDropdown, klugheitDropdown, intuitionDropdown, charismaDropdown, ffDropdown, gewandtheitDropdown, koDropdown, kkDropdown;
    public Toggle mutToggle, klugheitToggle, intuitionToggle, charismaToggle, ffToggle, gewandtheitToggle, koToggle, kkToggle;

    public void ResetUI(){
        mutDropdown.value = 0;
        klugheitDropdown.value = 0;
        intuitionDropdown.value = 0;
        charismaDropdown.value = 0;
        ffDropdown.value = 0;
        gewandtheitDropdown.value = 0;
        koDropdown.value = 0;
        kkDropdown.value = 0;

        mutToggle.isOn = false;
        klugheitToggle.isOn = false;
        intuitionToggle.isOn = false;
        charismaToggle.isOn = false;
        ffToggle.isOn = false;
        gewandtheitToggle.isOn = false;
        koToggle.isOn = false;
        kkToggle.isOn = false;


    }

}
