using UnityEditor;

public class CreateCustomScriptTemplate
{
    private const string screenScriptPath = "Assets/Scripts/Editor/CustomScriptsTemplates/ScreenScriptTemplate.cs.txt";
    private const string commandScriptPath = "Assets/Scripts/Editor/CustomScriptsTemplates/CommandTemplate.cs.txt";
    private const string dataCommandScriptPath = "Assets/Scripts/Editor/CustomScriptsTemplates/DataCommandTemplate.cs.txt";

    [MenuItem(itemName: "Assets/Create/Custom Screen", isValidateFunction: false, priority: 51)]
    public static void CreateScreenFromTemplate()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(screenScriptPath, "ScreenTemplate.cs");
    }

    [MenuItem(itemName: "Assets/Create/Custom Command", isValidateFunction: false, priority: 51)]
    public static void CreateCommandFromTemplate()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(commandScriptPath, "CommandTemplate.cs");
    }

    [MenuItem(itemName: "Assets/Create/Custom Data Command", isValidateFunction: false, priority: 51)]
    public static void CreateDataCommandFromTemplate()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(dataCommandScriptPath, "DataCommandTemplate.cs");
    }
}
