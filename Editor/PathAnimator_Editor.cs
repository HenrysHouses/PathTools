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
    [CustomEditor(typeof(PathAnimatorController))]
    public class PathAnimator_Editor : Editor
    {
    private PathAnimatorController script;

        AnimationCurve curve;

        private void OnEnable()
        {
            script = target as PathAnimatorController;
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.FloatField(new GUIContent("Animation Length:", "Time in seconds"), script.getAnimLength(), EditorStyles.boldLabel);

            base.OnInspectorGUI();

            if(GUILayout.Button("Animate"))
            {
                if(EditorApplication.isPlaying)
                {
                    GameObject card = Instantiate(script.testAnimationObj);
                    AnimationEventManager.getInstance.requestAnimation(script.AnimationName, card);
                }
                else
                    Debug.LogWarning("Play the editor to test the animation");
            }
        }
    }
}
#endif