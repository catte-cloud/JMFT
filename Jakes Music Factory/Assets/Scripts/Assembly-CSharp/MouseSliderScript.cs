using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000044 RID: 68
public class MouseSliderScript : MonoBehaviour
{
	// Token: 0x06000136 RID: 310 RVA: 0x00007894 File Offset: 0x00005A94
	private void Start()
	{
		this.slider = base.GetComponent<Slider>();
		if (PlayerPrefs.GetFloat("MouseSensitivity") == 0f)
		{
			PlayerPrefs.SetFloat("MouseSensitvity", 1f);
		}
		this.slider.value = PlayerPrefs.GetFloat("MouseSensitivity");
	}

	// Token: 0x06000137 RID: 311 RVA: 0x000078E2 File Offset: 0x00005AE2
	private void Update()
	{
		PlayerPrefs.SetFloat("MouseSensitivity", this.slider.value);
	}

	// Token: 0x040001E7 RID: 487
	public Slider slider;
}
