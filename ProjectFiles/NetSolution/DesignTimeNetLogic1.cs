#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.UI;
using FTOptix.Retentivity;
using FTOptix.NativeUI;
using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.NetLogic;
using FTOptix.Recipe;
#endregion

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void Method1()
    {
        // Insert code to be executed by the method
        var myFolder = Project.Current.Get<Folder>("Model/Variables");
        if (myFolder != null) { 
            myFolder.Delete(); 
        }
        var myNewFolder = InformationModel.Make<Folder>("Variables");
        var myModelFolder = Project.Current.Get<Folder>("Model");
        myModelFolder.Add(myNewFolder);
        for (int i = 0; i < 20; i++)
        {
            var myVar = InformationModel.MakeVariable("aTag" + i, OpcUa.DataTypes.Int32);
            Project.Current.Get("Model/Variables").Add(myVar);

        }
    }


}
