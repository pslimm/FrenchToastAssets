using UnityEngine;
using System.Collections;

public class OswaldsPersistentMixtape : MonoBehaviour 
{
	private static OswaldsPersistentMixtape mixtape;
	public static OswaldsPersistentMixtape GetMixtape()
	{
		return mixtape;
	}
	
	void Awake()
	{
		if (mixtape && mixtape != this)
		{
			Destroy(this.gameObject);
		}

		else
		{
			mixtape = this;
		}

		DontDestroyOnLoad(this.gameObject);
	}
}
