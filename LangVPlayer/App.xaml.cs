using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using LangVPlayer.Resources;
using LangVPlayer.Services;

namespace LangVPlayer;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    /// <summary>
    /// File path passed via command line arguments / РџСѓС‚СЊ Рє С„Р°Р№Р»Сѓ РёР· Р°СЂРіСѓРјРµРЅС‚РѕРІ РєРѕРјР°РЅРґРЅРѕР№ СЃС‚СЂРѕРєРё
    /// </summary>
    public string? StartupFilePath { get; private set; }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        // Initialize localization / РРЅРёС†РёР°Р»РёР·Р°С†РёСЏ Р»РѕРєР°Р»РёР·Р°С†РёРё
        var settings = SettingsService.Load();
        Strings.Init(settings.Language);
        
        // Check command line arguments for file path / РџСЂРѕРІРµСЂРєР° Р°СЂРіСѓРјРµРЅС‚РѕРІ РєРѕРјР°РЅРґРЅРѕР№ СЃС‚СЂРѕРєРё РґР»СЏ РїСѓС‚Рё Рє С„Р°Р№Р»Сѓ
        if (e.Args.Length > 0)
        {
            string potentialPath = e.Args[0];
            
            // Check if argument is a valid file path / РџСЂРѕРІРµСЂРєР° СЏРІР»СЏРµС‚СЃСЏ Р»Рё Р°СЂРіСѓРјРµРЅС‚ РІР°Р»РёРґРЅС‹Рј РїСѓС‚С‘Рј Рє С„Р°Р№Р»Сѓ
            if (File.Exists(potentialPath))
            {
                StartupFilePath = potentialPath;
            }
        }
        
        // Create and show main window / РЎРѕР·РґР°С‚СЊ Рё РїРѕРєР°Р·Р°С‚СЊ РіР»Р°РІРЅРѕРµ РѕРєРЅРѕ
        var mainWindow = new MainWindow();
        mainWindow.Show();
        
        // If we have a startup file, load it after window is ready / Р•СЃР»Рё РµСЃС‚СЊ С„Р°Р№Р» РїСЂРё Р·Р°РїСѓСЃРєРµ, Р·Р°РіСЂСѓР·РёС‚СЊ РµРіРѕ РїРѕСЃР»Рµ РіРѕС‚РѕРІРЅРѕСЃС‚Рё РѕРєРЅР°
        if (!string.IsNullOrEmpty(StartupFilePath))
        {
            mainWindow.LoadVideoFromCommandLine(StartupFilePath);
        }
    }
}

