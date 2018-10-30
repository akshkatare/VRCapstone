using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CommandControl : MonoBehaviour {
	public Text t;
	public void getCommand(string s)
	{
        if (s.Contains("समय")) {
			t.text =System.DateTime.Now.Hour+" : " +System.DateTime.Now.Minute ;
            
        }
        else if (s.Contains("दिन"))
        {
			t.text =System.DateTime.Now.Date+" ";
            //Day
        }
        else if (s.Contains("नाम") && s.Contains("क्या"))
        {
            if (s.Contains("तुम्हारा"))
			{ t.text = "मेरा नाम मन है";
            }
            else
                if (s.Contains("मेरा"))
            {
                //ownersname
            }
        }
        else
		{t.text = GameObject.Find ("GlyphSub").GetComponent<glyphsubScript> ().retSubString (s); }

    }
}
