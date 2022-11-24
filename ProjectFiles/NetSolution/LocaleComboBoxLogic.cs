#region Using directives
using System;
using FTOptix.CoreBase;
using FTOptix.HMIProject;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.OPCUAServer;
using FTOptix.Recipe;
#endregion

public class LocaleComboBoxLogic : BaseNetLogic
{
    public override void Start()
    {
        var localeCombo = (ComboBox)Owner;

        var projectLocales = (string[])Project.Current.GetVariable("Locales").Value;
        var modelLocales = InformationModel.MakeObject("Locales");
        modelLocales.Children.Clear();

        foreach (var locale in projectLocales)
        {
            var language = InformationModel.MakeVariable(locale, OpcUa.DataTypes.String);
            language.Value = locale;
            modelLocales.Add(language);
        }

        LogicObject.Add(modelLocales);
        localeCombo.Model = modelLocales.NodeId;
    }
}
