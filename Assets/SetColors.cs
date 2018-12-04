using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColors : MonoBehaviour {
    Image img;
    Color orgcolor;
    private void Start()
    {
        img = this.GetComponent<Image>();
        orgcolor = img.color;
    }
    public void SetOriginal()
    { img.color = orgcolor; }
    public void SetSelected()
    { img.color = Color.blue; }
    public void SetUse()
    { img.color = Color.green; }
}
