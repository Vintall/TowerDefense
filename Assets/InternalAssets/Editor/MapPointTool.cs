using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EditorTools;
using UnityEditor;

[EditorTool(displayName: "Trajectory Traccer", typeof(MapPoint))]
public class MapPointTool : EditorTool
{
    public Texture2D tool_icon;
    public override GUIContent toolbarIcon
    {
        get
        {
            return new GUIContent
            {
                image = tool_icon,
                text = "Trajectory Traccer"
            };
        }
    }
    public override void OnToolGUI(EditorWindow window)
    {
        bool on_click = false;
        bool on_click_up = false;
        if(Input.GetMouseButton(0))
        {
            on_click = true;
        }



        if(Input.GetMouseButtonUp(0) && on_click)
        {
            on_click_up = true;
        }
    }
    

}
