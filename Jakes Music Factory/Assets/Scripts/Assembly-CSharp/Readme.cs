using System;
using UnityEngine;

// Token: 0x02000061 RID: 97
[CreateAssetMenu(fileName = "New read me", menuName = "CM Assets/Read me", order = 1)]
public class Readme : ScriptableObject
{
	// Token: 0x040002D6 RID: 726
	[TextArea]
	public string message;
}
