using System;
using UnityEngine;

// Token: 0x02000063 RID: 99
public static class TheBCMHT_Helper
{
	// Token: 0x060001C6 RID: 454 RVA: 0x0000A730 File Offset: 0x00008930
	public static int getMaxValueFromTileType(TileType tileType)
	{
		int result = 1000;
		if (tileType == TileType.Corner || tileType == TileType.End)
		{
			result = 1;
		}
		return result;
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x0000A74E File Offset: 0x0000894E
	public static Vector3 getVector3FromDir(int direction)
	{
		return (new Vector3[]
		{
			Vector3.forward,
			Vector3.right,
			Vector3.back,
			Vector3.left
		})[direction];
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x0000A78C File Offset: 0x0000898C
	public static Material getSampleFloor(bool v132)
	{
		return Resources.Load<Material>("Samples/" + (v132 ? "V1.3.2/Ph_Floor" : "Ph_Floor"));
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x0000A7AC File Offset: 0x000089AC
	public static Material getSampleWall(bool v132)
	{
		return Resources.Load<Material>("Samples/" + (v132 ? "V1.3.2/Ph_Wall" : "Ph_Wall"));
	}

	// Token: 0x060001CA RID: 458 RVA: 0x0000A7CC File Offset: 0x000089CC
	public static Material getSampleCeiling(bool v132)
	{
		return Resources.Load<Material>("Samples/" + (v132 ? "V1.3.2/Ph_Ceiling" : "Ph_Ceiling"));
	}

	// Token: 0x060001CB RID: 459 RVA: 0x0000A7EC File Offset: 0x000089EC
	public static int intClampBySize(int value, int size)
	{
		return Mathf.Clamp(value, 0, size - 1);
	}

	// Token: 0x060001CC RID: 460 RVA: 0x0000A7F8 File Offset: 0x000089F8
	public static GameObject getCornMazeFlag()
	{
		return Resources.Load<GameObject>("Environment/Flag");
	}

	// Token: 0x060001CD RID: 461 RVA: 0x0000A804 File Offset: 0x00008A04
	public static Sprite getCornMazeFlagSampleSprite()
	{
		return Resources.Load<Sprite>("Samples/Placeholder_Flag");
	}

	// Token: 0x060001CE RID: 462 RVA: 0x0000A810 File Offset: 0x00008A10
	public static GameObject getCornMazeSign()
	{
		return Resources.Load<GameObject>("Environment/Sign");
	}

	// Token: 0x060001CF RID: 463 RVA: 0x0000A81C File Offset: 0x00008A1C
	public static Sprite getCornMazeSignSampleSprite()
	{
		return Resources.Load<Sprite>("Samples/Placeholder_Sign");
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x0000A828 File Offset: 0x00008A28
	public static RoomChildDat[,] createRoomData(int sizeX, int sizeY)
	{
		if (sizeX < 2 || sizeY < 2)
		{
			Debug.LogWarning(string.Concat(new object[]
			{
				"failed to create a room data size (",
				sizeX,
				", ",
				sizeY,
				")"
			}));
			return null;
		}
		RoomChildDat[,] array = new RoomChildDat[sizeX, sizeY];
		for (int i = 0; i < sizeX; i++)
		{
			for (int j = 0; j < sizeY; j++)
			{
				array[i, j] = new RoomChildDat();
				if (i == 0 && j == 0)
				{
					array[i, j].tileType = TileType.Corner;
					array[i, j].tileIndex = 0;
				}
				else if (i == 0 && j == sizeY - 1)
				{
					array[i, j].tileType = TileType.Corner;
					array[i, j].tileIndex = 1;
				}
				else if (i == sizeX - 1 && j == 0)
				{
					array[i, j].tileType = TileType.Corner;
					array[i, j].tileIndex = 3;
				}
				else if (i == sizeX - 1 && j == sizeY - 1)
				{
					array[i, j].tileType = TileType.Corner;
					array[i, j].tileIndex = 2;
				}
				else if (i == 0 && j > 0 && j <= sizeY - 2)
				{
					array[i, j].tileType = TileType.Single;
					array[i, j].tileIndex = 3;
				}
				else if (i > 0 && i <= sizeX - 2 && j == sizeY - 1)
				{
					array[i, j].tileType = TileType.Single;
					array[i, j].tileIndex = 0;
				}
				else if (i > 0 && i <= sizeX - 2 && j == 0)
				{
					array[i, j].tileType = TileType.Single;
					array[i, j].tileIndex = 2;
				}
				else if (i == sizeX - 1 && j > 0 && j <= sizeY - 2)
				{
					array[i, j].tileType = TileType.Single;
					array[i, j].tileIndex = 1;
				}
				else if (i > 0 && j > 0 && i <= sizeX - 2 && j <= sizeY - 2)
				{
					array[i, j].tileType = TileType.Open;
				}
			}
		}
		return array;
	}
}
