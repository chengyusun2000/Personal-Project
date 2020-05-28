using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor;
public class DialogueGraph : EditorWindow
{

    private DialogueGraphView _graphView;





    [MenuItem("Graph/DialogueGraph")]
    public static void OpenDialogueGraphWindow()
    {
        var window = GetWindow<DialogueGraph>();
        window.titleContent = new GUIContent("Dialogue Graph");
    }
    private void OnEnable()
    {
        ConstructGraphView();
        GenerateToolBar();
    }
    private void OnDisable()
    {
        rootVisualElement.Remove(_graphView);
    }

    private void GenerateToolBar()
    {
        var toolbar = new Toolbar();
        var button = new Button(()=>{
            _graphView.CreateNode("Dialogue Node");

        });
        button.text = "Create Node";
        toolbar.Add(button);
        rootVisualElement.Add(toolbar);
    }
    private void ConstructGraphView()
    {
        _graphView = new DialogueGraphView
        {
            name = "Dialogue Graph"
        };
        _graphView.StretchToParentSize();
        rootVisualElement.Add(_graphView);
    }

}
