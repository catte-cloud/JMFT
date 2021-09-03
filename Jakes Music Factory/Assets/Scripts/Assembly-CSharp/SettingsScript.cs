using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200005C RID: 92
public class SettingsScript : MonoBehaviour
{
	// Token: 0x060001A7 RID: 423 RVA: 0x0000A061 File Offset: 0x00008261
	public void SetQuality(int QualityIndex)
	{
		QualitySettings.SetQualityLevel(QualityIndex);
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x0000A069 File Offset: 0x00008269
	public void SetFullScreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x0000A074 File Offset: 0x00008274
	public void Start()
	{
		this.resolutions = Screen.resolutions;
		this.resolutionDropdown.ClearOptions();
		List<string> list = new List<string>();
		int value = 0;
		for (int i = 0; i < this.resolutions.Length; i++)
		{
			string item = this.resolutions[i].width + " x " + this.resolutions[i].height;
			list.Add(item);
			if (this.resolutions[i].width == Screen.currentResolution.width && this.resolutions[i].height == Screen.currentResolution.height)
			{
				value = i;
			}
		}
		this.resolutionDropdown.AddOptions(list);
		this.resolutionDropdown.value = value;
		this.resolutionDropdown.RefreshShownValue();
	}

	// Token: 0x040002B4 RID: 692
	public bool isFullscreen;

	// Token: 0x040002B5 RID: 693
	private Resolution[] resolutions;

	// Token: 0x040002B6 RID: 694
	public Dropdown resolutionDropdown;
}
