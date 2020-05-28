using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using System;
public class DialogueGraphView : GraphView
{
    public readonly Vector2 DefaultNodeSize = new Vector2(150, 200);
    public DialogueGraphView()
    {
        //styleSheets.Add(Resources.Load<StyleSheet>("Assets/Dialogue system/Editor/Dialogue.uss"));
        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);


        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        var grid = new GridBackground();
        Insert(0, grid);
        grid.StretchToParentSize();

        AddElement(GenerateEntryPointNode());
    }



    private Port GeneratePort(DialogueNode node,Direction direction,Port.Capacity capacity=Port.Capacity.Single)
    {
        return node.InstantiatePort(Orientation.Horizontal, direction, capacity, typeof(float));//arbitrary type
    }



    private DialogueNode GenerateEntryPointNode()
    {
        var node = new DialogueNode
        {
            title = "Start",
            GUID = Guid.NewGuid().ToString(),
            DialogueText="ENTRYPOINT",
            EntryPoint=true
            
        
        };
       var generatedPort= GeneratePort(node, Direction.Output);
        generatedPort.portName = "Next";
        node.outputContainer.Add(generatedPort);


        node.RefreshExpandedState();
        node.RefreshPorts();
        node.SetPosition(new Rect(100, 100, 150,200));
        return node;
    }


    private void AddChoicePort(DialogueNode dialogueNode)
    {
        var generatePort = GeneratePort(dialogueNode, Direction.Output);
        var outputPortCount = dialogueNode.outputContainer.Query("connector").ToList().Count;
        var outputPortName = $"Choice{outputPortCount}";
        dialogueNode.outputContainer.Add(generatePort);
        dialogueNode.RefreshExpandedState();
        dialogueNode.RefreshPorts();
    }



    public DialogueNode CreateDialogueNode(string NodeName)
    {
        var dialogueNode = new DialogueNode
        {
            title = NodeName,
            DialogueText = NodeName,
            GUID = Guid.NewGuid().ToString()
        };
        var InputPort = GeneratePort(dialogueNode, Direction.Input, Port.Capacity.Multi);
        InputPort.portName = "Input";
        dialogueNode.inputContainer.Add(InputPort);

        var button = new Button(() =>
          {
              AddChoicePort(dialogueNode);
          });

        button.text = "New Choice";
        dialogueNode.titleContainer.Add(button);

        dialogueNode.RefreshExpandedState();
        dialogueNode.RefreshPorts();
        dialogueNode.SetPosition(new Rect(Vector2.zero, DefaultNodeSize));

        return dialogueNode;
    }


    public void CreateNode(string name)
    {
        AddElement(CreateDialogueNode(name));
        
    }


    public override List<Port> GetCompatiblePorts(Port StartPort, NodeAdapter nodeAdapter)
    {
        var compatiblePorts = new List<Port>();
        ports.ForEach((port) =>
        {
            if (StartPort != port && StartPort.node != port.node)
            {
                compatiblePorts.Add(port);
            }
        });
        return compatiblePorts;
    }
}
