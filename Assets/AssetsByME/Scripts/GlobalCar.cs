using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCar : MonoBehaviour {
    public static GlobalCar Instance;
    public int CarTyp;
    public GameObject TrackWindow;
 
    public void redCar()
    {
        CarTyp = 1;
        TrackWindow.SetActive(true);
    }
    public void blueCar()
    {
        CarTyp = 2;
        TrackWindow.SetActive(true);
    }
    public void policeCae()
    {
        CarTyp = 3;
        TrackWindow.SetActive(true);
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
