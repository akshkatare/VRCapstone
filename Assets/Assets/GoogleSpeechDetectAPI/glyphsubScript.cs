using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glyphsubScript : MonoBehaviour {

	char temp;
	string retString="";
	public string retSubString(string s)
	{
		retString = "";
		char[] c=s.ToCharArray();
		for( int i=0;i<c.Length;i++)
		{
			if(c[i]=='\u093F')
			{
				temp=c[i];
				c[i]=c[i-1];
				c[i-1]=temp;
			}
			if(c[i]=='\u094d')
			{

				int f=c[i-1];

				if (f == 2325)
					f = 62266;
				if (f == 2326)
					f = 62267;
				if (f == 2327)
					f = 62268;
				if (f == 2328)
					f = 62269;
				if (f == 2330)
					f = 62270;
				if (f == 2332)
					f = 62271;
				if (f == 2333)
					f = 62272;
				if (f == 2334)
					f = 62275;
				if (f == 2339)
					f = 62276;
				if (f == 2340)
					f = 62277;
				if (f == 2341)
					f = 62278;
				if (f == 2325)
					f = 62266;
				if (f == 2343)
					f = 62279;
				if (f == 2344)
					f = 62282;
				if (f == 2346)
					f = 62283;
				if (f == 2347)
					f = 62284;
				if (f == 2348)
					f = 62285;
				if (f == 2350)
					f = 62288;
				if (f == 2351)
					f = 62289;
				if (f == 2354)
					f = 62290;
				if (f == 2358)
					f = 62291;
				if (f == 2359)
					f = 62298;
				if (f == 2360)
					f = 62299;
				if (f == 2361)
					f = 62296;
				if (f == 2362)
					f = 62297;
	
									
					c[i-1]='^';
				c [i] =(char)( f);

			}	
		}

		for (int i = 0; i < c.Length; i++) {
			if (c [i] == '^') {
			
				continue;
			} else {
				retString += c [i];
			}
		}

		return retString;
	}
}
