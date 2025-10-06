using UnityEngine;

public class lootcounter : MonoBehaviour
{
    private int lootcount;
    public void addcount ()
    {
        lootcount++;
    }
    public int getcount () 
    { 
        return lootcount; 
    }
}
