using System.IO;
using UnityEditor;
using UnityEngine;

public static class Exporter {

    private static readonly string _ExportPath = "ExportedPackages/template-package.unitypackage";

    [MenuItem("OMGG/Export Package")] // Allow Unity to call this method from the menu bar
    public static void ExportPackage()
    {
        // All path to export from Assets folder
        string[] assetsToExport = {
            "Assets/OMGG/Package/template-package/Demo",
            "Assets/OMGG/Package/template-package/Scripts",
            "Assets/OMGG/Package/template-package/Resources",
            "Assets/OMGG/Package/template-package/Editor"
        };

        // Create an export folder if needed
        string dir = Path.GetDirectoryName(_ExportPath);

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        // Export the package
        AssetDatabase.ExportPackage(assetsToExport, _ExportPath, ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies);

        Debug.Log($"Export completed: {_ExportPath}");
    }
}
