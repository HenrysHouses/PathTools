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

using UnityEngine;

namespace HH.PathingTools
{
	[System.Serializable]
	public class OrientedPoint
	{
		public Vector3 pos;
		public Quaternion rot;
		
		public OrientedPoint()
		{
			this.pos = default;
			this.rot = default;
		}
		
		public OrientedPoint(Vector3 pos, Quaternion rot)
		{
			this.pos = pos;
			this.rot = rot;
		}
		
		public OrientedPoint(Vector3 pos, Vector3 forward)
		{
			this.pos = pos;
			this.rot = Quaternion.LookRotation(forward);
		}
		
		public Vector3 LocalToWorldPos(Vector3 localSpacePos)
		{
			return pos + rot * localSpacePos;
		}
		
		public Vector3 LocalToWorldVect(Vector3 localSpacePos)
		{
			return rot * localSpacePos;
		}
		
	}
}