// * Pathing Tools
// *
// * Copyright (C) 2022  Henrik Hustoft
// *
// * This program is free software: you can redistribute it and/or modify
// * it under the terms of the GNU General Public License as published by
// * the Free Software Foundation, either version 3 of the License, or
// * (at your option) any later version.
// *
// * This program is distributed in the hope that it will be useful,
// * but WITHOUT ANY WARRANTY; without even the implied warranty of
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// * GNU General Public License for more details.
// *
// * You should have received a copy of the GNU General Public License
// * along with this program.  If not, see <http://www.gnu.org/licenses/>.

#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using HH.PathingTools;

namespace HH.PathingToolsEditor
{
	static public class PathCreator
	{	
		[MenuItem("GameObject/Level Design/Path", false, 10)]
		static public void CreatePath()
		{
			if(!EditorApplication.isPlaying)
			{
				GameObject gameObject = new GameObject("Path");
				gameObject.hideFlags = HideFlags.NotEditable;
				PathController controller = gameObject.AddComponent<PathController>();
				controller.hideFlags = HideFlags.None;
				for (int i = 0; i < 2; i++)
				{
					GameObject controlPoint = new GameObject();
					controlPoint.transform.SetParent(gameObject.transform);
					controlPoint.name = "p" + i;
					controlPoint.transform.localScale = new Vector3(0,0,3);
					controlPoint.AddComponent<PathExtender>();
					controller.controlPoints.Add(controlPoint.transform);
				}
			}
			else
				Debug.LogWarning("Only create new paths while not in play");
		}
	}
}
#endif