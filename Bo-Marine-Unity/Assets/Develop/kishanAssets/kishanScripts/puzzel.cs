using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class puzzel : MonoBehaviour
{
    List<string> colours = new List<string>() { "blue", "red", "green", "purple", "yellow" };
    private int allHit = 2;

    void Start()
    {
        chooseRandomMushroom();
    }

    void Update()
    {
        if (allHit == 3)
        {
            chooseRandomMushroom();
        }
    }

    public void chooseRandomMushroom()
    {

        List<string> randomizedList = colours.OrderBy(a => Random.value).ToList();
    }

    // stap 1: list die moet je shufflen (random)
    // stap 2: Zorg ervoor dat de mushrrom gaat oplichten als de index 0 is. 
    // Stap 3: Zorg ervoor dat als je de mushroom een klap geeft dat die mushroom uit gaat. (Uit de list verweiderd wordt).
    // Stap 4: Doe het voor de andere ook. 
    // Stap 5: Voer de functie drie keer uit.
}
