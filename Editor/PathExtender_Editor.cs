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
	[CustomEditor( typeof( PathExtender ) )]
	public class PathExtender_Editor : Editor
	{
		private PathController newSegment;
		void OnSceneGUI()
		{
			PathExtender t = target as PathExtender;

			Event e = Event.current;
			
			// Get scene view mouse pos and camera
			Camera cam = Camera.current;
			Vector3 pos = Event.current.mousePosition;
			if(cam != null)
			{
				pos.z = -cam.worldToCameraMatrix.MultiplyPoint(t.transform.position).z;
				pos.y = Screen.height - pos.y - 36.0f; // ??? Why that offset?!
				pos = cam.ScreenToWorldPoint (pos);
			}

			// If ctrl + mouse0, create a new curve
			if(e.type == EventType.MouseDown && e.ToString().Contains("Modifiers: Control"))
			{
				createCurve(t.GetComponentInParent<PathController>(), pos);
			}
		}
		
		private void createCurve(PathController target, Vector3 position)
		{
			if(target != null)
			{
				GameObject newPoint = new GameObject();
				newPoint.transform.SetParent(target.gameObject.transform);
				newPoint.transform.position = position;
				int n = target.controlPoints.Count;
				newPoint.name = "p"+n;
				newPoint.AddComponent<PathExtender>();
				target.controlPoints.Add(newPoint.transform);
			}
		}
	}
}
#endif