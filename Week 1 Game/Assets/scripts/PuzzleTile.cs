using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTile : MonoBehaviour
{
    // Start is called before the first frame update
    public bool active = false;
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((this.name == "RedTile" && other.name == "RedBlock") || (this.name == "BlueTile" && other.name == "BlueBlock") || (this.name == "GreenTile" && other.name == "GreenBlock") || (this.name == "PurpleTile" && other.name == "PurpleBlock"))
        {
            active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((this.name == "RedTile" && other.name == "RedBlock") || (this.name == "BlueTile" && other.name == "BlueBlock") || (this.name == "GreenTile" && other.name == "GreenBlock") || (this.name == "PurpleTile" && other.name == "PurpleBlock"))
        {
            active = false;
        }
    }
}
