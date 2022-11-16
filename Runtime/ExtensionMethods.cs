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
	public static class ExtensionMethods
	{
		public static float RemapT (this float from, float fromMin, float fromMax, float toMin,  float toMax)
		{
			var fromAbs  =  from - fromMin;
			var fromMaxAbs = fromMax - fromMin;      
		
			var normal = fromAbs / fromMaxAbs;
	
			var toMaxAbs = toMax - toMin;
			var toAbs = toMaxAbs * normal;
	
			var to = toAbs + toMin;
		
			if(to < 0) // Only positive numbers
				to *= -1;
			return to;
		}
		
		public static float Remap (this float from, float fromMin, float fromMax, float toMin,  float toMax)
		{
			var fromAbs  =  from - fromMin;
			var fromMaxAbs = fromMax - fromMin;      
		
			var normal = fromAbs / fromMaxAbs;
	
			var toMaxAbs = toMax - toMin;
			var toAbs = toMaxAbs * normal;
	
			var to = toAbs + toMin;
		
			return to;
		}

		public static void SetGlobalScale (this Transform transform, Vector3 globalScale)
		{
			transform.localScale = Vector3.one;
			transform.localScale = new Vector3 (globalScale.x/transform.lossyScale.x, globalScale.y/transform.lossyScale.y, globalScale.z/transform.lossyScale.z);
		}
	}
}