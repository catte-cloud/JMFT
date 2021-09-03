using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000060 RID: 96
public class MazeCell
{
	// Token: 0x060001BE RID: 446 RVA: 0x0000A460 File Offset: 0x00008660
	public void InitializeCell()
	{
		if (this.initialized)
		{
			return;
		}
		if (Resources.Load("Tiles/Full") == null)
		{
			Debug.LogWarning("Initialization failed, Tiles/Full doesn't exist");
			return;
		}
		this.availableDirs.Add(0);
		this.availableDirs.Add(1);
		this.availableDirs.Add(2);
		this.availableDirs.Add(3);
		MeshRenderer[] array = new MeshRenderer[4];
		foreach (MeshRenderer meshRenderer in UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Tiles/Full"), this.gridPosition, Quaternion.identity, this.parent).GetComponentsInChildren<MeshRenderer>())
		{
			if (meshRenderer.gameObject.name == "Wall")
			{
				array[0] = meshRenderer;
			}
			else if (meshRenderer.gameObject.name == "Wall (1)")
			{
				array[1] = meshRenderer;
			}
			else if (meshRenderer.gameObject.name == "Wall (2)")
			{
				array[2] = meshRenderer;
			}
			else if (meshRenderer.gameObject.name == "Wall (3)")
			{
				array[3] = meshRenderer;
			}
			else if (meshRenderer.gameObject.name.Contains("Floor"))
			{
				this.floor = meshRenderer;
			}
			else if (meshRenderer.gameObject.name.Contains("Ceiling"))
			{
				this.ceiling = meshRenderer;
			}
		}
		for (int j = 0; j < array.Length; j++)
		{
			this.walls.Add(array[j]);
		}
	}

	// Token: 0x060001BF RID: 447 RVA: 0x0000A5DE File Offset: 0x000087DE
	public void RemoveCeiling()
	{
		if (this.ceiling != null)
		{
			UnityEngine.Object.DestroyImmediate(this.ceiling.gameObject);
		}
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x0000A600 File Offset: 0x00008800
	public void ApplyMaterials(Material ceiling, Material wall, Material floor)
	{
		foreach (MeshRenderer meshRenderer in this.walls)
		{
			meshRenderer.sharedMaterial = wall;
		}
		this.floor.sharedMaterial = floor;
		if (this.ceiling != null)
		{
			this.ceiling.sharedMaterial = ceiling;
		}
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0000A678 File Offset: 0x00008878
	public void DestroyWall(int direction)
	{
		if (this.availableDirs.Contains(direction))
		{
			MeshRenderer meshRenderer = this.walls[this.GetIntegerFromDir(direction)];
			this.walls.Remove(meshRenderer);
			UnityEngine.Object.DestroyImmediate(meshRenderer.gameObject);
			this.availableDirs.Remove(direction);
		}
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x0000A6CC File Offset: 0x000088CC
	private int GetIntegerFromDir(int direction)
	{
		for (int i = 0; i < this.availableDirs.Count; i++)
		{
			if (this.availableDirs[i] == direction)
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x040002CE RID: 718
	private List<int> availableDirs = new List<int>();

	// Token: 0x040002CF RID: 719
	private List<MeshRenderer> walls = new List<MeshRenderer>();

	// Token: 0x040002D0 RID: 720
	private MeshRenderer floor;

	// Token: 0x040002D1 RID: 721
	private MeshRenderer ceiling;

	// Token: 0x040002D2 RID: 722
	public bool initialized;

	// Token: 0x040002D3 RID: 723
	public Vector3 gridPosition;

	// Token: 0x040002D4 RID: 724
	public Transform parent;

	// Token: 0x040002D5 RID: 725
	public bool visited;
}
