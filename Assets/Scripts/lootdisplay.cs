using TMPro;
using UnityEngine;

public class lootdisplay : MonoBehaviour
{
    [SerializeField] private lootcounter countloot;
    [SerializeField] private TMP_Text numbdisplay;
    private void Update()
    {
        numbdisplay.text = countloot.getcount().ToString();
    }
}
